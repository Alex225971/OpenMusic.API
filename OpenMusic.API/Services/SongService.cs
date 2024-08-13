using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.DataProtection;
using System.IO;

namespace OpenMusic.API.Services
{
    public class SongService : ISongService
    {
        private readonly Cloudinary _cloudinary;
        public SongService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
            _cloudinary = new Cloudinary(acc);
        }
        public async Task<RawUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new RawUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();

                var uploadParams = new RawUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = "openmusicapi-songs",
                    Overwrite = true
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}
