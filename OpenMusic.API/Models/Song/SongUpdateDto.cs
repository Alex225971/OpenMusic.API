namespace OpenMusic.API.Models.Song
{
    public class SongUpdateDto : BaseDto
    {
        public string? Title { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public int? ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public int? AlbumId { get; set; }
        public string? AlbumtName { get; set; }
    }
}
