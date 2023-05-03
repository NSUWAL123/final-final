using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql.BackendMessages;

namespace ApplicationDevelopment.Infrastructure.Services
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService()
        {
            Account account = new Account(
               "djiwumijb", "319152568248643", "5KR692tcjK8wYJoAB-qddT3GIQA"
                );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadLicense(string base64Image)
        {
            var bytes = Convert.FromBase64String(base64Image);

            using var stream = new MemoryStream(bytes);
            var uploadParams = new ImageUploadParams
            {
                Folder = "License",
                PublicId = Guid.NewGuid().ToString(),
                //AllowedFormats = new string[] { "pdf", "png" },
                Format = "jpg",
                File = new FileDescription("license", stream)
            };

            if (_cloudinary != null)
            {
                var result = await _cloudinary.UploadAsync(uploadParams);
                return result.SecureUrl.AbsoluteUri;
            }
            else
            {
                throw new Exception("Cloudinary object is null or not initialized.");
            }
            

          
        }

        public async Task<string> UploadCitizenship(string base64Image)
        {
            var bytes = Convert.FromBase64String(base64Image);

            using var stream = new MemoryStream(bytes);
            var uploadParams = new ImageUploadParams
            {
                Folder = "Citizenship",
                PublicId = Guid.NewGuid().ToString(),
                //AllowedFormats = new string[] { "pdf", "png" },
                Format = "jpg",
                File = new FileDescription("citizenship", stream)
            };
                       if (_cloudinary != null)
            {
                var result = await _cloudinary.UploadAsync(uploadParams);
                return result.SecureUrl.AbsoluteUri;
            }
            else
            {
                throw new Exception("Cloudinary object is null or not initialized.");
            }

            
        }

        public async Task<string> UploadCar(string base64Image)
        {
            var bytes = Convert.FromBase64String(base64Image);

            using var stream = new MemoryStream(bytes);
            var uploadParams = new ImageUploadParams
            {
                Folder = "Car",
                PublicId = Guid.NewGuid().ToString(),
                //AllowedFormats = new string[] { "pdf", "png" },
                Format = "jpg",
                File = new FileDescription("car", stream)
            };
            if (_cloudinary != null)
            {
                var result = await _cloudinary.UploadAsync(uploadParams);
                return result.SecureUrl.AbsoluteUri;
            }
            else
            {
                throw new Exception("Cloudinary object is null or not initialized.");
            }
        }
    }
}