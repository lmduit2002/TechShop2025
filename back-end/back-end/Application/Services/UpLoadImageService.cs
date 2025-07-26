using back_end.Application.Helpers;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;

namespace back_end.Application.Services
{
    public class UpLoadImageService
    {
        private Cloudinary _cloudinary;
        public UpLoadImageService(IOptions<CloudinarySettings> cloudinaryConfig) 
        {
            var account = new Account(
                cloudinaryConfig.Value.CloudName, 
                cloudinaryConfig.Value.ApiKey, 
                cloudinaryConfig.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }
    }
}
