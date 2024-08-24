using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Playlist;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Models.SearchResults
{
    public class SearchResultsDto
    {
        public List<SongPlaybackDto> Songs { get; set; }
        public List<AlbumReadOnlyDto> Albums { get; set; }
        public List<ArtistDetailsDto> Artists { get; set; }
        public List<PlaylistPlaybackDto> Playlists { get; set; }
    }
}
