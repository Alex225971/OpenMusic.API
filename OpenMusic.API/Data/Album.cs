namespace OpenMusic.API.Data
{
    public class Album
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string? Genre { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
        public int ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
    }
}
