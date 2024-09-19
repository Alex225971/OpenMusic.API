using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Repositories;
using OpenMusic.API.Services;

namespace OpenMusic.API.Controllers
{
    public class AlbumsController : BaseApiController
    {
        private readonly IAlbumRepository _albumRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPhotoService _photoService;
        private readonly ISongService _songService;

        public AlbumsController(IAlbumRepository albumRepo, IMapper mapper, IWebHostEnvironment webHostEnvironment, IPhotoService photoService, ISongService songService)
        {
            _albumRepo = albumRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _photoService = photoService;
            _songService = songService;
        }

        // GET: api/Albums
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumReadOnlyDto>>> GetAlbumsAsync()
        {
            var albums = await _albumRepo.GetAllReadOnlyAsync();
            return Ok(albums);
        }

        // GET: api/Albums/5
        [Authorize(Roles = "Admin")]
        [HttpGet("/api/Albums/Artist/{id}")]
        public async Task<ActionResult<AlbumDetailsDto>> GetAlbumsFromArtistAsync(int id)
        {
            try
            {
                var album = await _albumRepo.GetAlbumsFromArtist(id);

                if (album == null)
                {
                    return NotFound();
                }
                return Ok(album);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: api/Albums/5
        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumDetailsDto>> GetAlbumAsync(int id)
        {
            try
            {
                var album = await _albumRepo.GetAlbumDetailsAsync(id);

                if (album == null)
                {
                    return NotFound();
                }
                return Ok(album);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: api/Albums
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<AlbumCreateDto>> CreateAlbumAsync([FromForm] AlbumCreateDto albumDto, IFormFile image)
        {
            var album = _mapper.Map<Album>(albumDto);

            //Adding the image to cloudinary and setting image url
            if (image != null)
            {
                var result = await _photoService.AddPhotoAsync(image);
                if (result.Error != null) return BadRequest(result.Error.Message);

                album.Image = result.SecureUrl.AbsoluteUri;
                album.ImagePublicId = result.PublicId;
            }

            if (albumDto.Songs != null) {

                for (int i = 0; i < albumDto.Songs.Count; i++)
                {

                    if (albumDto.Songs.ElementAt(i).SongFile != null)
                    {
                        var result = await _songService.AddSongAsync(albumDto.Songs.ElementAt(i).SongFile);
                        if (result.Error != null) return BadRequest(result.Error.Message);

                        album.Songs.ElementAt(i).SongUrl = result.SecureUrl.AbsoluteUri;
                        album.Songs.ElementAt(i).SongPublicId = result.PublicId;
                        album.Songs.ElementAt(i).ArtistId = album.ArtistId;
                    }
                }
                //TODO - fix this to stop returning 500s even when it works
            }

            if (albumDto.Genres != null)
            {
                for (int i = 0; i < album.AlbumGenres.Count(); i++)
                {
                    album.AlbumGenres.ElementAt(i).GenreId = albumDto.Genres.ElementAt(i).Id;
                }
            }

            //Need to make sure arist IDs stay null for child objects when mappings are done to avoid foreign key constraints 
            if (album.ArtistId == null)
            {
                foreach (var song in album.Songs)
                {
                    song.ArtistId = null;
                }
            }


            await _albumRepo.AddAsync(album);

            return StatusCode(201, album);
        }

        // PUT: api/Albums/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> EditAlbum(int id, [FromForm]AlbumUpdateDto albumDto)
        {
            //TODO - make sure an album can be edited without affecting songs, and songs can be edited throguh album
            var album = await _albumRepo.GetAsync(id);

            if (id != album.Id)
            {
                return BadRequest();
            }

            if (album == null)
            {
                return NotFound();
            }

            //_mapper.Map(albumDto, album);
            //var mappedAlbum = _mapper.Map<Album>(album);

            try
            {
                await _albumRepo.UpdateAlbumWithSongs(id, albumDto);
            } catch (Exception ex)
            {
                throw;
            }

            //try
            //{
            //    await _albumRepo.UpdateAsync(mappedAlbum);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!await AlbumExistsAsync(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // DELETE: api/Albums/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            var album = await _albumRepo.GetAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            if (album.Image == null) return BadRequest("Could not find a photo associated with this record, file not deleted");

            var result = await _photoService.DeletePhotoAsync(album.ImagePublicId);
            if (result.Error != null) return BadRequest(result.Error.Message);

            await _albumRepo.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> AlbumExistsAsync(int id)
        {
            return await _albumRepo.Exists(id);
        }
    }
}
