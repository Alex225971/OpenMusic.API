using CloudinaryDotNet.Actions;

namespace OpenMusic.API.Services
{
    public interface ISongService
    {
        Task<RawUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}