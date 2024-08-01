using Microsoft.AspNetCore.Identity;
using YamlDotNet.Core.Tokens;

namespace OpenMusic.API.Data
{
    public partial class Playlist
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public string? Image { get; set; }
        public int? CreatorId { get; set; }
        public virtual IdentityUser? Creator { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
