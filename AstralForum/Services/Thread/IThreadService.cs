using AstralForum.ServiceModels;

namespace AstralForum.Services.Thread
{
    public interface IThreadService
    {
        Task<ThreadDto> CreateThread(ThreadDto model);
        Task<ThreadDto> EditThread(ThreadDto commentDto);
        ThreadDto GetThreadById(int id);
		Task<ThreadDto> DeleteThread(ThreadDto commentDto);
    }
}
