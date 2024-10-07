using OpenMusic.API.Data;
using OpenMusic.API.Models.Genre;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Models.Album
{
    public class AlbumSearchDto : BaseDto
    {
        public string Title { get; set; }
        public int? ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Image { get; set; }
        public List<SongSearchDto> Songs { get; set; }

    }
}
