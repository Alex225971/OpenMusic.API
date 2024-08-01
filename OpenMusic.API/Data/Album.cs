namespace OpenMusic.API.Data
{
    public class Album
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
        public string? Genre { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
    }
}
