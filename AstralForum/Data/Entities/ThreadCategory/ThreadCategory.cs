using AstralForum.Data.Entities.Thread;
using AstralForum.ServiceModels;

namespace AstralForum.Data.Entities.ThreadCategory
{
    public class ThreadCategory : MetadataBaseEntity
    {
		public string? ImageUrl { get; set; }
		public string CategoryName { get; set; }
        public string Description { get; set; }

        public List<Thread.Thread> Threads { get; set; }
    }
}

