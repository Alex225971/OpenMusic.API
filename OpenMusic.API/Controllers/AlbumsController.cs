using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<AlbumReadOnlyDto>>> GetAlbumsAsync(int id, IFormCollection collection)
        {
            var albums = await _albumRepo.GetAllAsync();
            return Ok(albums);
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public ActionResult GetAlbum(int id, IFormCollection collection)
        {
            return Ok();
        }

        // POST: api/Albums
        [HttpPost]
        public async Task<ActionResult<AlbumCreateDto>> CreateAlbumAsync(AlbumCreateDto albumDto)
        {
            var album = _mapper.Map<Album>(albumDto);
            if (string.IsNullOrEmpty(albumDto.Image) == false)
            {
                album.Image = "";
            }

            await _albumRepo.AddAsync(album);

            return CreatedAtAction(nameof(GetAlbum), new { id = album.Id }, album);
        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public ActionResult EditAlbum(int id, IFormCollection collection)
        {
            return Ok();
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public ActionResult DeleteAlbum(int id, IFormCollection collection)
        {
            return Ok();
        }
    }
}
