using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Data.Entities.Thread;
using AstralForum.Data.Entities.ThreadCategory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AstralForum.Data.Entities.Reply;
using AstralForum.Models.Notification;
using AstralForum.Data.Entities.Tag;
using AstralForum.Models;
using Thread = AstralForum.Data.Entities.Thread.Thread;

namespace AstralForum.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		public DbSet<Ban> Bans { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentAttachment> CommentsAttachment { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<ReactionType> ReactionsType { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<ThreadAttachment> ThreadsAttachment { get; set; }
        public DbSet<Entities.ThreadCategory.ThreadCategory> ThreadCategories { get; set; }
		public DbSet<Notification> Notifications { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<ThreadTag> PostsTags { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<ReplyReaction> ReplyReactions { get; set; }

        public DbSet<ReplyReport> ReplyReports { get; set; }

        public DbSet<Tag> Tags { get; set; }


    }
}