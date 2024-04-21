using Microsoft.AspNetCore.Identity;

namespace AstralForum.Data.Entities
{
	public class User : IdentityUser<int>
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string ProfilePictureUrl { get; set; } = string.Empty;
		public DateTime DateOfCreation { get; set; }
		public bool IsBanned { get; set; }
		public DateTime BanEnd { get; set; }
		public DateTime TimeOut { get; set; }

		public User()
		{
			DateOfCreation = DateTime.Now;
		}
	}

}