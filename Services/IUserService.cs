using AstralForum.Data.Entities;
using AstralForum.ServiceModels;

namespace AstralForum.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserById(int id);
    }
}
