namespace OpenMusic.API.Data
{
    public partial class Song
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string SongUrl { get; set; }
        public int? ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
        public int? AlbumId { get; set; }
        public virtual Album? Album { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public int TotalListeners { get; set; }

    }
}
