using AstralForum.Data.Entities;
using AstralForum.Models.Admin;
using AstralForum.Models.User;
using AstralForum.ServiceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.IdentityModel.Tokens;

namespace AstralForum.Services
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService userService;

		public UserFacade(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
		}
		public async Task<AllUsersViewModel> GetAllUsers()
        {
            List<UserDto> userDtos = await userService.GetAllUsersAsync();
            AllUsersViewModel viewModel = new AllUsersViewModel()
            {
                Users = userDtos
            };
            
            return viewModel;
        }
		public async Task<UserInfoModel> GetUser(int id)
		{
			UserDto userDto = await userService.GetUserById(id);
			UserInfoModel viewModel = new UserInfoModel()
			{
				Users = userDto,
			};

			return viewModel;
		}
	}
}
