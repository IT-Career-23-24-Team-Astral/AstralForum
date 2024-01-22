using AstralForum.Data.Entities.Comments;
using AstralForum.Data.Entities.Reactions;
using AstralForum.Data.Entities.Threads;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<CommentsAttachment> CommentsAttachment { get; set; }
        public DbSet<Reactions> Reactions { get; set; }
        public DbSet<ReactionsType> ReactionsType { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<ThreadsAttachment> ThreadsAttachment { get; set; }
    }
}
