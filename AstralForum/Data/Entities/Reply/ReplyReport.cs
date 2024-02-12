namespace AstralForum.Data.Entities.Reply
{
    public class ReplyReport : MetadataBaseEntity
    {

        public string Text { get; set; }

        public int ReplyId { get; set; }

        public Reply Reply { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
