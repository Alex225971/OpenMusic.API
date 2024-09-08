using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Genre;
using OpenMusic.API.Repositories;

namespace OpenMusic.API.Controllers
{
    public class GenresController :BaseApiController
    {

        private readonly IGenreRepository _genreRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GenresController(IGenreRepository genreRepo, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _genreRepo = genreRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreReadOnlyDto>>> GetGenresAsync()
        {
            var genres = await _genreRepo.GetAllAsync();
            return Ok(genres);
        }

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult<Genre>> CreateGenreAsync(GenreReadOnlyDto genreReadOnlyDto)
        {
            var genre = _mapper.Map<Genre>(genreReadOnlyDto);

            await _genreRepo.AddAsync(genre);

            return StatusCode(201, genre);
        }
    }
}
