using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Repositories;

namespace OpenMusic.API.Controllers
{
    public class AlbumsController : BaseApiController
    {
        private readonly IAlbumRepository _albumRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AlbumsController(IAlbumRepository albumRepo, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _albumRepo = albumRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumReadOnlyDto>>> GetAlbumsAsync()
        {
            var albums = await _albumRepo.GetAllReadOnlyAsync();
            return Ok(albums);
        }

        // GET: api/Albums/5
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
        [HttpPost("CreateAlbumAsync")]
        public async Task<ActionResult<AlbumCreateDto>> CreateAlbumAsync(AlbumCreateDto albumDto)
        {
            var album = _mapper.Map<Album>(albumDto);

            await _albumRepo.AddAsync(album);

            return CreatedAtAction("CreateSAlbumAsync", new { id = album.Id }, album);
        }

        // PUT: api/Albums/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditAlbum(int id, AlbumUpdateDto albumDto)
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

            _mapper.Map(albumDto, album);

            try
            {
                await _albumRepo.UpdateAsync(album);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AlbumExistsAsync(id))
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

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            var album = await _albumRepo.GetAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            await _albumRepo.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> AlbumExistsAsync(int id)
        {
            return await _albumRepo.Exists(id);
        }
    }
}
