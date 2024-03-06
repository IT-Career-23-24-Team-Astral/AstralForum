using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models.Admin;
using AstralForum.ServiceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Services
{


    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users
                .Select(user => user.ToDto())
                .ToListAsync();

            return users;
        }
        public async Task<UserDto> GetUserById(int id)
        {
            var user = _userManager.Users
				.Where(user => user.Id == id)
                .Select(user => user.ToDto())
                .FirstOrDefault();
                
            return user;
        }
    }
}
