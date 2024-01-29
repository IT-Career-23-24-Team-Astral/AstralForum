using AstralForum.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Ban> Bans { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<CommentsAttachment> CommentsAttachment { get; set; }
        public DbSet<Reactions> Reactions { get; set; }
        public DbSet<ReactionsType> ReactionsType { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<ThreadsAttachment> ThreadsAttachment { get; set; }
        public DbSet<ThreadsCategory> Category { get; set; }
    }
}
