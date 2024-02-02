using AstralForum.Data.Entities;
using AstralForum.Repositories.Interfaces;
using AstralForum.Models.Thread;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models.Category;
using AstralForum.Data.Entities.Thread;
using AstralForum.Models.Comment;


namespace AstralForum.Repositories
{
    public class ThreadRepository :CommonRepository<Post>, IThreadRepository
    {
        private readonly ApplicationDbContext context;

        public ThreadRepository(ApplicationDbContext context) : base(context) 
        {
            this.context = context;  
        }
        public void AddThread(ThreadFormModel model, User id)
        {
            Post thread = new Post()
            {
                Title = model.Title,
                Text = model.Text,
                ImageUrl = model.ImageUrl,
                ThreadCategory = model.ThreadCategory,
                CreatedById = model.CreatedById
            };
            context.Threads.Add(thread);
            context.SaveChanges();
        }
        public List<ThreadViewModel> GetAllThreadsByThreadCategory(int ThreadCategory)
        {
            return context.Threads.Where(x => x.ThreadCategory == ThreadCategory).Select(x => new ThreadViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text,
                ImageUrl = x.ImageUrl,
                CreatedById = x.CreatedById,
                CreatedOn = x.CreatedOn
            }).ToList();
        }
        public void Edit(Post thread, ThreadFormModel model)
        {
            thread.Title = model.Title;
            thread.Text = model.Text;
            thread.ImageUrl = model.ImageUrl;
            thread.ThreadCategory = model.ThreadCategory;
            context.Threads.Update(thread);
            context.SaveChanges();
        }
        public void Delete(Post thread)
        {
            context.Threads.Remove(thread);
            context.SaveChanges();
        }
    }
}
