using AstralForum.Models.Admin;
using AstralForum.Models.User;
using AstralForum.ServiceModels;

namespace AstralForum.Services
{
    public interface IUserFacade
    {
        Task<AllUsersViewModel> GetAllUsers();
        Task<UserInfoModel> GetUser(int id);
    }
}
