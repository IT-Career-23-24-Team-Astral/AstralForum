using AstralForum.Data.Entities;
using AstralForum.Models.Thread;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Thread
{
    public interface IThreadFacade
    {
        ThreadTableViewModel GetThreadTableViewModel(ThreadDto threadDto);
        ThreadDto NoResultsThread(int id);


		ThreadDto SearchPostsByCreatedBy(int id, string searchQuery);
        ThreadDto SearchPostsByText(int id, string searchQuery);
        ThreadDto SearchPostsByBoth(int id, string searchQuery);

		Task<ThreadDto> CreateThread(ThreadCreationFormModel threadForm, User createdById);
        
    }
}
