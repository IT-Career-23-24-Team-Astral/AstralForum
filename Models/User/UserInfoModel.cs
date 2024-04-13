using AstralForum.Data.Entities;
using AstralForum.ServiceModels;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace AstralForum.Models.User
{
    public class UserInfoModel
    {
		public UserDto Users { get; set; }
		public List<Role> Roles { get; set; }
    }
}
