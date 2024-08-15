using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using OpenMusic.API.Models.SearchResults;
using OpenMusic.API.Models.Song;
using OpenMusic.API.Repositories;

namespace OpenMusic.API.Controllers
{
    public class SearchController : BaseApiController
    {
        private readonly ISongRepository _songRepository;
        private readonly IArtistRepository _artistRepository;
        public SearchController(ISongRepository songRepository, IArtistRepository artistRepository)
        {
            _songRepository = songRepository;
            _artistRepository = artistRepository;
        }

        // GET: api/Search/string
        [HttpGet("search")]
        public async Task<ActionResult<SearchResultsDto>> SearchForSongsAsync(string queryString)
        {
            try
            {
                var songs = await _songRepository.SearchForSongAsync(queryString);

                var result = new SearchResultsDto
                {
                    Songs = songs
                };

                return Ok(result);
            }
            catch (Exception ex) 
            { 
                throw;
            }


        }
    }
}
