using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Models.Artist
{
    public class ArtistSearchDto : BaseDto
    {
        public string Name { get; set; }
        public List<AlbumSearchDto> Albums { get; set; }
    }
}
