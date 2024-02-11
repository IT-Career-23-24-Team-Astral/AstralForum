namespace AstralForum.Data.Entities
{
    public class Message : MetadataBaseEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public string ReceiverId { get; set; }

        public User Receiver { get; set; }


        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
