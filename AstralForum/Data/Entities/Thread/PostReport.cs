namespace AstralForum.Data.Entities.Thread
{
    public class PostReport
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int PostId { get; set; }

        public Thread Post { get; set; }

        public string CreatedById { get; set; }

        public User CreatedBy { get; set; }


        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}