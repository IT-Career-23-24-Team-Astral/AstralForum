using AstralForum.Data.Entities;
using AstralForum.Repositories.Interfaces;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Data.Entities.Thread;
using AstralForum.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using AstralForum.Data.Entities.Comment;


namespace AstralForum.Repositories
{
    public class ThreadRepository :CommonRepository<Post>, IThreadRepository
    {
        private readonly ApplicationDbContext context;

        public ThreadRepository(ApplicationDbContext context) : base(context) 
        {
            this.context = context;  
        }
        public void AddThread(ThreadModel model, User id)
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
        public List<ThreadModel> GetAllThreadsByThreadCategory(int ThreadCategory)
        {
            return context.Threads.Where(x => x.ThreadCategory == ThreadCategory).Select(x => new ThreadModel()
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text,
                ImageUrl = x.ImageUrl,
                CreatedById = x.CreatedById,
                CreatedOn = x.CreatedOn
            }).ToList();
        }
        public void Edit(Post thread, ThreadModel model)
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
