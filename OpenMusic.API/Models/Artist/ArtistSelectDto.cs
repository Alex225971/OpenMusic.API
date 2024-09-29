using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Song;
using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.Artist
{
    public class ArtistSelectDto : BaseDto
    {
        public string Name { get; set; }
    }
}
