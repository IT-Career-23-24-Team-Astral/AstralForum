using AstralForum.Data.Entities.Thread;

namespace AstralForum.Data.Entities.ThreadCategory
{
    public class ThreadCategory : MetadataBaseEntity
    {
        public string CategoryName { get; set; }

        public List<Post> Threads { get; set; }
    }
}
