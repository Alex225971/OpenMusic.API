﻿namespace OpenMusic.API.Models.User
{
    public class AuthResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
    }
}
