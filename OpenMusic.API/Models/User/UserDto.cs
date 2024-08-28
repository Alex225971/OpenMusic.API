using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.User
{
    public class UserDto : UserLoginDto
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        public string? Role { get; set; }
    }
}
