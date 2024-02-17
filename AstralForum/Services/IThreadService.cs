using AstralForum.ServiceModels;

namespace AstralForum.Services
{
    public interface IThreadService
    {
        Task<ThreadDto> CreateThread(ThreadDto model);
        Task<ThreadDto> EditThread(ThreadDto commentDto);
        Task<List<ThreadDto>> GetAllThreadsByThreadCategoryId(int id);
        Task<ThreadDto> DeleteThread(ThreadDto commentDto);
    }
}
