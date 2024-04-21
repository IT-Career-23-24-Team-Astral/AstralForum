namespace AstralForum.ServiceModels
{
	public class UserDto
	{
        public int Id { get; set; }
        public string UserName { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ProfilePictureUrl { get; set; }
		public DateTime DateOfCreation { get; set; }
		public bool IsBanned { get; set; }
        public DateTime TimeOut { get; set; }
    }
}
