using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Repositories;
using YamlDotNet.Core.Tokens;

namespace OpenMusic.API.Controllers
{
    public class ArtistsController : BaseApiController
    {
        private readonly IArtistRepository _artistRepo;
        private readonly IMapper _mapper;

        public ArtistsController(IArtistRepository artistRepo, IMapper mapper)
        {
            _artistRepo = artistRepo;
            _mapper = mapper;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistReadOnlyDto>>> GetArtistsAsync()
        {
            var artists = await _artistRepo.GetAllAsync();
            return Ok(artists);
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDetailsDto>> GetArtistAsync(int id)
        {
            try
            {
                var artist = await _artistRepo.GetArtistDetailsAsync(id);

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

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtistCreateDto>> CreateArtistAsync(ArtistCreateDto artistDto)
        {
            try
            {
                var artist = _mapper.Map<Artist>(artistDto);
                await _artistRepo.AddAsync(artist);

                return CreatedAtAction(nameof(GetArtistsAsync), new { id = artist.Id }, artist);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Artists/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditArtist(int id, ArtistUpdateDto artistDto)
        {
            if (id != artistDto.Id)
            {
                return BadRequest();
            }
            var artist = await _artistRepo.GetAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            _mapper.Map(artistDto, artist);

            try
            {
                await _artistRepo.UpdateAsync(artist);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ArtistExistsAsync(id))
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

        // DELETE: api/Artists/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var artist = await _artistRepo.GetAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            await _artistRepo.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ArtistExistsAsync(int id)
        {
            return await _artistRepo.Exists(id);
        }
    }
}
