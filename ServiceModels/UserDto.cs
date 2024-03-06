using AstralForum.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace AstralForum.ServiceModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
