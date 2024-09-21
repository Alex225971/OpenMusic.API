using OpenMusic.API.Data;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Models.Playlist
{
    public class PlaylistPlaybackDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImagePublicId { get; set; }
        public string CreatorId { get; set; }
        public List<SongPlaybackDto>? Songs { get; set; }
        public List<PlaylistSong>? PlaylistSongs { get; set; }

    }
}
