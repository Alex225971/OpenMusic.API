using System.Text.Json.Serialization;

namespace OpenMusic.API.Data
{
    public partial class Song
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string SongUrl { get; set; }
        public string SongPublicId { get; set; }
        public int? ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
        public int? AlbumId { get; set; }
        public virtual Album? Album { get; set; }
        public int Year { get; set; }
        public int TotalListeners { get; set; }
        public virtual ICollection<SongGenre> SongGenres { get; set; } = new List<SongGenre>();
        [JsonIgnore]
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly LastUpdatedAt { get; set; }

    }
}
