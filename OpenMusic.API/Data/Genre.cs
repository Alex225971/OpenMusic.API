using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Data
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();

    }

    public class AlbumGenre
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }

    public class SongGenre
    {
        public int SongId { get; set; }
        public Song Song { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
