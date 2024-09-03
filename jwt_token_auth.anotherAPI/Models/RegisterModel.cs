using System;
using System.Collections.Generic;

namespace jwt_token_auth.anotherAPI.Models
{
    public partial class RegisterModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
