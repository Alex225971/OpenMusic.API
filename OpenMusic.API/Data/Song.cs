namespace OpenMusic.API.Data
{
    public partial class Song
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Url { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
    }
}
