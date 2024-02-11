namespace AstralForum.Data.Entities.Reply
{
    public class ReplyReport : MetadataBaseEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int ReplyId { get; set; }

        public Reply Reply { get; set; }

        public string CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
