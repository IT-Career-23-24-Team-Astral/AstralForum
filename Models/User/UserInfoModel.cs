using AstralForum.Data.Entities;
using AstralForum.ServiceModels;

namespace AstralForum.Models.User
{
    public class UserInfoModel
    {
		public UserDto Users { get; set; }
		public List<Role> Roles { get; set; }

	}
}
