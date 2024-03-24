using CloudinaryDotNet.Actions;

namespace AstralForum.Services
{
    public interface ICloudinaryService
    {
		ImageUploadResult UploadImage(IFormFile file);
	}
}
