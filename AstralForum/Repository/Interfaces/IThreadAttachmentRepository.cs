using AstralForum.Data.Entities.Thread;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models;

namespace AstralForum.Repositories.Interfaces
{
    public interface IThreadAttachmentRepository : ICommonRepository<ThreadAttachment>
    {
        public IEnumerable<ThreadAttachmentModel> GetThreadAttachmentByThreadId(int id);
        public void AddAttachment(ThreadAttachmentModel model);
        public void Delete(ThreadAttachmentModel model);
    }
}