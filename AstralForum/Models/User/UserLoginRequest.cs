using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.User
{
    public class UserLoginRequest : AuthenticationBasicRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
