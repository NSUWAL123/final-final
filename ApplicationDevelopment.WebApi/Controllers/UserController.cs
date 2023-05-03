using ApplicationDevelopment.Application.Common.Interfaces;
using ApplicationDevelopment.Application.DTOS;
using ApplicationDevelopment.Domain.Entities;
using ApplicationDevelopment.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApplicationDevelopment.WebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly IApplicationDbContext _dbContext;

        private readonly CloudinaryService _cloudinaryService;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IApplicationDbContext dbContext, CloudinaryService cloudinaryService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _cloudinaryService = cloudinaryService;
        }

        [HttpPost]
        //[Authorize(policy: "RequireAdminOrStaffOrRole")]
        //[Authorize(Roles = "admin, staff,user")]
        [Route("api/users/{userId}/change-password")]
        public async Task<IActionResult> ChangePassword(string userId, [FromBody] ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPut("api/users/{userId}/edit-profile")]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileDto editProfileDto, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }
            // Retrieve the related customer entity
            var customer = await _dbContext.Customer.SingleOrDefaultAsync(c => c.UserId == userId);
            if (!string.IsNullOrEmpty(editProfileDto.UserName))
            {
                user.UserName = editProfileDto.UserName;
            }
            // Update user properties
           

            // Update user in database
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Update related customer entity if it exists
            if (customer != null)
            {
                // Update customer address
                if (editProfileDto.Address != null)
                {
                    customer.Address = new Address
                    {
                        Street = editProfileDto.Address.Street,
                        City = editProfileDto.Address.City,
                    };
                }

                // Upload and update customer license photo and citizenship photo
                if (!string.IsNullOrEmpty(editProfileDto.LicensePhoto))
                {
                    customer.LicensePhoto = await _cloudinaryService.UploadLicense(editProfileDto.LicensePhoto);
                }
                if (!string.IsNullOrEmpty(editProfileDto.CitizenshipPhoto))
                {
                    customer.CitizenshipPhoto = await _cloudinaryService.UploadCitizenship(editProfileDto.CitizenshipPhoto);
                }

                await _dbContext.SaveChangesAsync();
            }

            return Ok("Profile updated successfully.");


        }

    }
}
