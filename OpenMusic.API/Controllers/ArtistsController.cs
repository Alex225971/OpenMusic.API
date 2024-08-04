using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<ArtistsController> _logger;

        public ArtistsController(IArtistRepository artistRepo, IMapper mapper, ILogger<ArtistsController> logger)
        {
            _artistRepo = artistRepo;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Artists
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ArtistReadOnlyDto>>> GetArtistsAsync()
        {
            var artists = await _artistRepo.GetAllAsync();
            return Ok(artists);
        }

        // POST: api/Artist
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
                _logger.LogError(e, $"Error performing POST in{nameof(CreateArtistAsync)}");
                return StatusCode(500, "Internal server error");
            }
        }

        //// POST: ArtistController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return Ok();
        //    }
        //}
    }
}
