using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.User
{
	public class ResetPasswordRequest
	{
		[Required, MinLength(6, ErrorMessage = "Please enter at least 6 characters!")]
		public string Password { get; set; } = string.Empty;
		[Required, Compare("Password")]
		public string ConfirmPassword { get; set; } = string.Empty;
	}
}
