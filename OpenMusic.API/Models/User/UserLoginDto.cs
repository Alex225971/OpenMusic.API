using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.User
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
