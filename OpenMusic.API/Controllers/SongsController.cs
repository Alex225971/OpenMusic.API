using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Song;
using OpenMusic.API.Repositories;
using OpenMusic.API.Services;
using System.ComponentModel;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace OpenMusic.API.Controllers
{
    public class SongsController : BaseApiController
    {
        private readonly ISongRepository _songRepo;
        private readonly IMapper _mapper;
        private readonly ISongService _songService;

        public SongsController(ISongRepository songRepo, IMapper mapper, ISongService songService)
        {
            _songRepo = songRepo;
            _mapper = mapper;
            _songService = songService;
        }

        // GET: api/Songs
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongPlaybackDto>>> GetSongsAsync()
        {
            var songs = await _songRepo.GetAllSongDetailsAsync();

            return Ok(songs);
        }

        // GET: api/Songs/Artist/5
        [Authorize(Roles = "Admin,User")]
        [HttpGet("/api/Songs/Artist/{id}")]
        public async Task<ActionResult<IEnumerable<SongPlaybackDto>>> GetSongsFromArtist(int id)
        {
            try
            {
                var songs = await _songRepo.GetSongsFromArtistAsync(id);

                if (songs == null)
                {
                    return NotFound();
                }
                return Ok(songs);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: api/Songs/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<SongPlaybackDto>> GetSongForPlaybackAsync(int id)
        {
            try
            {
                var song = await _songRepo.GetForPlaybackAsync(id);

                if (song == null)
                {
                    return NotFound();
                }
                return Ok(song);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin,Artist")]
        [HttpPost]
        public async Task<ActionResult<SongCreateDto>> CreateSongAsync([FromForm] SongCreateDto songDto, IFormFile songFile)
        {
            var song = _mapper.Map<Song>(songDto);
            //song.ReleaseDate = DateOnly.Parse(songDto.ReleaseDate);

            if(songFile != null)
            {
                var result = await _songService.AddSongAsync(songFile);
                if (result.Error != null) return BadRequest(result.Error.Message);

                song.SongUrl = result.SecureUrl.AbsoluteUri;
                song.SongPublicId = result.PublicId;
            }
            if (songDto.Genres != null) 
            { 
                for (int i = 0; i < song.SongGenres.Count(); i++)
                {
                    song.SongGenres.ElementAt(i).GenreId = songDto.Genres.ElementAt(i).Id;
                }
            }
            
            await _songRepo.AddAsync(song);

            return StatusCode(201, song);
        }

        // PUT: api/Songs/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> EditSong(int id, SongUpdateDto songDto)
        {
            //TODO - make sure a song can be edited with and without album id
            var songWithId = await _songRepo.GetSongForUpdateAsync(id);

            if (id != songWithId.Id)
            {
                return BadRequest();
            }
            var song = await _songRepo.GetAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            //Because a song can have no related album(single) and no related artist(unkown artist)
            //We want to check for "null" values before inserting and set them to null so they wont throw a foreign key conflict
            if (song.AlbumId != null)
            {
                song.AlbumId = songDto.AlbumId;
            }
            if (song.ArtistId != null)
            {
                song.ArtistId = songDto.ArtistId;
            }

            _mapper.Map(songDto, song);

            try
            {
                await _songRepo.UpdateAsync(song);
            }
            catch (Exception ex)
            {
                if (!await SongExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Songs/id
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            var song = await _songRepo.GetAsync(id);
            
            if (song == null)
            {
                return NotFound();
            }

            if (song.SongUrl == null) return BadRequest("Could not find a song file associated with this record, file not deleted");

            var result = await _songService.DeleteSongAsync(song.SongPublicId);
            if (result.Error != null) return BadRequest(result.Error.Message);

            await _songRepo.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> SongExistsAsync(int id)
        {
            return await _songRepo.Exists(id);
        }
    }
}
