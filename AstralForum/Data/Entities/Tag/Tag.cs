using AstralForum.Data.Entities.Thread;

namespace AstralForum.Data.Entities.Tag
{
    public class Tag
    {
        public int Id { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<ThreadTag> Threads { get; set; } = new HashSet<ThreadTag>();
    }
}
