using Microsoft.AspNetCore.Identity;

namespace AstralForum.Data.Entities
{
    public class User : IdentityUser<int> 
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfCreation { get; set; }
        public List<Role> Roles { get; set; }
        public User()
        {
            DateOfCreation = DateTime.Now;
        }
    }

}
