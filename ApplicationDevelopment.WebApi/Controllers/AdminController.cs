
using ApplicationDevelopment.Application.Common.Interfaces;
using ApplicationDevelopment.Application.DTOS;
using ApplicationDevelopment.Domain.Entities;
using ApplicationDevelopment.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebApi.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly IApplicationDbContext _dbContext;

        private readonly CloudinaryService _cloudinaryService;

        public AdminController(UserManager<User> userManager, SignInManager<User> signInManager, IApplicationDbContext dbContext, CloudinaryService cloudinaryService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _cloudinaryService = cloudinaryService;
        }

        [HttpPost]
        //[Authorize(Policy = "RequireAdminRole")]
        [Authorize(Roles = "admin")]
        [Route("/api/admin/enrollStaff")]
        public async Task<ResponseDTO> EnrollStaff([FromBody] EnrollStaffDTO model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return new ResponseDTO
                {
                    Status = "Error",
                    Message = "User already exists!"
                };

            Address address = new Address()
            {
                City = model.Address.City,
                Street = model.Address.Street
            };

            var addressId = await _dbContext.Address.AddAsync(address);
            await _dbContext.SaveChangesAsync();

        

            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Name,
                PhoneNumber = model.Phone,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return new ResponseDTO { Status = "Error", Message = "User creation failed! Please check user details and try again" };

            // Create a new staff and set its UserId to the newly created user's Id
            Staff staff= new()
            {
                UserId = user.Id,
                AddressId = addressId.Entity.Id,
              
            };

            // Add the new staff to the database context and save the changes
            _dbContext.Staff.Add(staff);
            await _dbContext.SaveChangesAsync();

            await _userManager.AddToRoleAsync(user, "Staff");

            return new ResponseDTO { Status = "Success", Message = "Staff created successfully" };
        }

      
    }
}
