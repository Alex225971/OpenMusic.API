using YamlDotNet.Core.Tokens;

namespace OpenMusic.API.Data
{
    public class UserLike
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? SongId { get; set; }
        public virtual Song? Song { get; set; }
    }
}
