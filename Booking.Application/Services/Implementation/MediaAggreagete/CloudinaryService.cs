using Booking.Application.ConfigurationOptions;
using Booking.Application.Services.Abstraction.MediaAggreagete;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Implementation.MediaAggreagete
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySetting> cloudinarySetting)
        {
            var setting = cloudinarySetting.Value;
            var account = new Account() { ApiKey = setting.ApiKey, ApiSecret = setting.ApiSecret, Cloud = setting.Cloud };
            _cloudinary = new Cloudinary(account);
        }
        public async Task<ImageUploadResult> UploadImage(IFormFile file)
        {
            var result = new ImageUploadResult();
            if(result != null)
            {
                using var stream = file.OpenReadStream();
                var uplaodParams = new ImageUploadParams() { File = new FileDescription(file.FileName, stream) };
                result = await _cloudinary.UploadAsync(uplaodParams);
            }
            return result;
        }

        public async Task<DeletionResult> DeleteImage(string publicId)
        {
            var result = await _cloudinary.DestroyAsync(new DeletionParams(publicId));
            return result;
        }

    }
}
