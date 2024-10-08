﻿namespace OpenMusic.API.Data
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string? Image { get; set; }
        public string ImagePublicId { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
        public int? ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
        public virtual ICollection<AlbumGenre> AlbumGenres { get; set; } = new List<AlbumGenre>();
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly LastUpdatedAt { get; set; }
    }
}
