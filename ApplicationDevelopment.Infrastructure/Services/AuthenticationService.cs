using ApplicationDevelopment.Application.Common.Interfaces;
using ApplicationDevelopment.Application.DTOS;
using ApplicationDevelopment.Domain.Entities;
using ApplicationDevelopment.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Sockets;

namespace ApplicationDevelopment.Infrastructure.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly IApplicationDbContext _dbContext;

        private readonly CloudinaryService _cloudinaryService;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager, IApplicationDbContext dbContext, CloudinaryService cloudinaryService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _cloudinaryService = cloudinaryService;
        }

        //public async Task<ResponseDTO> Register(RegisterDTO model)
        //{
        //    var userExists = await _userManager.FindByEmailAsync(model.Email);
        //    if (userExists != null)
        //        return new ResponseDTO
        //        {
        //            Status = "Error",
        //            Message = "User already exists!"

        //        };

        //    Address address = new Address()
        //    {
        //        City = model.Address.City,
        //        Street = model.Address.Street
        //    };

        //    var addressId = await _dbContext.Address.AddAsync(address);
        //    await _dbContext.SaveChangesAsync();

        //    var data = addressId.Entity.Id;

        //    var licenseUrl = await _cloudinaryService.UploadLicense(model.LicensePhoto);
        //    var citizenshipUrl = await _cloudinaryService.UploadCitizenship(model.CitizenshipPhoto);


        //    User user = new()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Name,
        //        PhoneNumber = model.Phone,
        //        AddressId = addressId.Entity.Id,
        //        LicensePhoto = licenseUrl,
        //        CitizenshipPhoto = citizenshipUrl,
        //    };

        //    Console.WriteLine(user);

        //    var result = await _userManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(user, "Customer");
        //    }
        //    await _dbContext.SaveChangesAsync();
        //    Console.WriteLine(result);
        //    if (!result.Succeeded)
        //        return new ResponseDTO { Status = "Error", Message = "User creation failed! Please check user details and try again" };




        //    return new ResponseDTO { Status = "Success", Message = "User created successfully"};
        //}

        public async Task<ResponseDTO> Register(RegisterDTO model)
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

            //var licenseUrl = await _cloudinaryService.UploadLicense(model.LicensePhoto);
            //var citizenshipUrl = await _cloudinaryService.UploadCitizenship(model.CitizenshipPhoto);

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

            // Create a new customer and set its UserId to the newly created user's Id
            Customer customer = new()
            {
                UserId = user.Id,
                AddressId = addressId.Entity.Id,
                //LicensePhoto = licenseUrl,
                //CitizenshipPhoto = citizenshipUrl,
            };

            // Add the new customer to the database context and save the changes
            _dbContext.Customer.Add(customer);
            await _dbContext.SaveChangesAsync();

            await _userManager.AddToRoleAsync(user, "Customer");

            return new ResponseDTO { Status = "Success", Message = "User created successfully" };
        }

        public async Task<ResponseDTO> Login(LoginDTO model)
        {
            // Find user by email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ResponseDTO()
                {
                    Message = "User login failed! Please check user details and try again!",
                    Status = "Error"
                };
            }

            // Sign in user with their username
            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);
            Console.WriteLine(result);
            if (result.Succeeded)
            {
                return new ResponseDTO()
                {
                    Message = "User logged in !",
                    Status = "Success"
                };
            }

            return new ResponseDTO()
            {
                Message = "User login failed! Please check user details and try again!",
                Status = "Error"
            };
        }

        public async Task<IEnumerable<UserDetailsDTO>> GetUserDetails()
        {
            var users = await _userManager.Users.Select(x => new
            {
                x.Email,
                x.UserName,
                x.EmailConfirmed,
                x.PhoneNumber,
             
            }).ToListAsync();


            var userDetails = new List<UserDetailsDTO>();

            foreach(var item in users)
            {

                var user = await _userManager.FindByEmailAsync(item.Email);
               Guid userId= Guid.Parse(user.Id);
                var customer = await _dbContext.Customer.FindAsync(userId);

                var userDetailsDTO = new UserDetailsDTO
                {
                    Email = item.Email,
                    Name = item.UserName,

                 

                };

                userDetails.Add(userDetailsDTO);
            }


            return userDetails;
        }
    }

}

