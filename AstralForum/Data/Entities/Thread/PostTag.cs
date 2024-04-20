namespace AstralForum.Data.Entities.Thread
{
    public class ThreadTag : BaseEntity
    {
        public int ThreadId { get; set; }

        public Thread Thread { get; set; }

        public int TagId { get; set; }
    }
}
