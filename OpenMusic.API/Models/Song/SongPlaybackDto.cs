namespace OpenMusic.API.Models.Song
{
    public class SongPlaybackDto : BaseDto
    {
        public string Title { get; set; }
        public string SongUrl { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
