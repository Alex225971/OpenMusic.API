namespace OpenMusic.API.Data
{
    public partial class Artist
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Bio { get; set; }
        public int TotalListeners { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
        public virtual ICollection<Album>? Albums { get; set; } = new List<Album>();
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly LastUpdatedAt { get; set; }
    }
}
