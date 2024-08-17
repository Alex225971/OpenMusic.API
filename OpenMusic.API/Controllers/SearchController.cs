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
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;

        public SearchController(ISongRepository songRepository, IArtistRepository artistRepository, IAlbumRepository albumRepository)
        {
            _songRepository = songRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
        }

        // GET: api/Search/string
        [HttpGet("search")]
        public async Task<ActionResult<SearchResultsDto>> SearchForSongsAsync(string queryString)
        {
            try
            {
                //TODO - find a more efficient way to search all of these
                var songs = await _songRepository.SearchForSongAsync(queryString);
                var albums = await _albumRepository.SearchForAlbumAsync(queryString);
                var artists = await _artistRepository.SearchForArtistAsync(queryString);

                var result = new SearchResultsDto
                {
                    Songs = songs,
                    Albums = albums,
                    Artists = artists
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
