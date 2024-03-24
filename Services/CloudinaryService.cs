using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace AstralForum.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly IConfiguration _config;

        private readonly Cloudinary cloudinary;

        public CloudinaryService(IConfiguration config)
        {
            _config = config;
            cloudinary = ConfigureCloudinary();
        }

        public Cloudinary ConfigureCloudinary()
        {
            Account account = new Account(
                _config["Cloudinary:CloudName"],
                _config["Cloudinary:APIKey"],
                _config["Cloudinary:APISecret"]);

            return new Cloudinary(account);
        }

        public ImageUploadResult UploadImage(IFormFile file)
        {
            var fileStream = new MemoryStream();
            file.CopyTo(fileStream);
            fileStream.Position = 0;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Path.GetRandomFileName(), fileStream)
            };
            return cloudinary.Upload(uploadParams);
        }
    }
}
