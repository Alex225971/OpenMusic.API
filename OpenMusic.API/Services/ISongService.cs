using CloudinaryDotNet.Actions;

namespace OpenMusic.API.Services
{
    public interface ISongService
    {
        Task<RawUploadResult> AddSongAsync(IFormFile file);
        Task<DeletionResult> DeleteSongAsync(string publicId);
    }
}