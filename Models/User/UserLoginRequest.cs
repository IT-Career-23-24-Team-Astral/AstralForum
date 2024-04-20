using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.User
{
    public class UserLoginRequest : AuthenticationBasicRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
