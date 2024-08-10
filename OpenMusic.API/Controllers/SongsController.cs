using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Song;
using OpenMusic.API.Repositories;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace OpenMusic.API.Controllers
{
    public class SongsController : BaseApiController
    {
        private readonly ISongRepository _songRepo;
        private readonly IMapper _mapper;

        public SongsController(ISongRepository songRepo, IMapper mapper)
        {
            _songRepo = songRepo;
            _mapper = mapper;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistReadOnlyDto>>> GetSongsAsync()
        {
            var songs = await _songRepo.GetAllAsync();
            return Ok(songs);
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongPlaybackDto>> GetSongForPlaybackAsync(int id)
        {
            try
            {
                var artist = await _songRepo.GetForPlaybackAsync(id);

                if (artist == null)
                {
                    return NotFound();
                }
                return Ok(artist);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateSongAsync")]
        public async Task<ActionResult<SongCreateDto>> CreateSongAsync(SongCreateDto songDto)
        {
           var song = _mapper.Map<Song>(songDto);
           //song.ReleaseDate = DateOnly.Parse(songDto.ReleaseDate);
           await _songRepo.AddAsync(song);

           return CreatedAtAction("CreateSongAsync", new { id = song.Id }, song);
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditSong(int id, SongUpdateDto songDto)
        {
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

            _mapper.Map(songDto, song);

            try
            {
                await _songRepo.UpdateAsync(song);
            }
            catch (DbUpdateConcurrencyException)
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
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            var song = await _songRepo.GetAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            await _songRepo.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> SongExistsAsync(int id)
        {
            return await _songRepo.Exists(id);
        }
    }
}
