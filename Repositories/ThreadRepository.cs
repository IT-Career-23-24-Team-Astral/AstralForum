using AstralForum.Data.Entities.Thread;
using AstralForum.ServiceModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using Thread = AstralForum.Data.Entities.Thread.Thread;

namespace AstralForum.Repositories
{
    public class ThreadRepository : CommonRepository<Data.Entities.Thread.Thread>
    {
        public ThreadRepository(ApplicationDbContext context) : base(context) { }

        public Thread GetThreadById(int id)
        {
            return context.Threads
                .Include(t => t.ThreadCategory)
                .Include(t => t.CreatedBy)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.CreatedBy)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Reactions)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Attachments)
                .Include(t => t.Reactions)
                .Include(t => t.Attachments)
                .Where(t => t.Id == id)
                .Single();
        }
        public void DeleteAllThreadsByUserId(int userId)
        {
            var threadsToDelete = context.Threads.Where(t => t.CreatedById == userId);

            foreach (var thread in threadsToDelete)
            {
                thread.IsHidden = true;
                thread.IsDeleted = true;
                context.SaveChanges();
            }
        }
        public async Task<List<Thread>> GetAllHiddenThreads()
        {
            return await context.Threads
                .Include(t => t.CreatedBy)
                .Where(t => t.IsHidden && t.IsDeleted == false)
                .ToListAsync();
        }
        public async Task<List<Thread>> GetAllDeletedThreads()
        {
            return await context.Threads
                .Include(t => t.CreatedBy)
                .Include(t => t.Title)
                .Include(t => t.Text)
                .Where(t => t.IsDeleted == true)
                .ToListAsync();
        }
        public Thread HideThread(int id)
        {
            var thread = context.Threads.FirstOrDefault(t => t.Id == id);
            thread.IsHidden = true;
            context.SaveChanges();
            return thread;
        }
        public Thread UnhideThread(int id)
        {
            var thread = context.Threads.FirstOrDefault(t => t.Id == id);
            thread.IsHidden = false;
            context.SaveChanges();
            return thread;
        }
        public Thread DeleteThread(int id)
        {
            var thread = context.Threads.FirstOrDefault(t => t.Id == id);
            thread.IsDeleted = true;
            context.SaveChanges();
            return thread;
        }
        public Thread GetDeletedThreadBack(int id)
        {
            var thread = context.Threads.FirstOrDefault(t => t.Id == id);
            thread.IsHidden = false;
            thread.IsDeleted = false;
            context.SaveChanges();
            return thread;
        }

        /*
        public void Edit(Post thread, ThreadModel model)
        {
            thread.Title = model.Title;
            thread.Text = model.Text;
            thread.ImageUrl = model.ImageUrl;
            thread.ThreadCategoryId = model.ThreadCategory;
            context.Threads.Update(thread);
            context.SaveChanges();
        }
        public void Delete(Post thread)
        {
            context.Threads.Remove(thread);
            context.SaveChanges();
        }*/
    }
}