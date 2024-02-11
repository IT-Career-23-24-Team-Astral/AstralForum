namespace AstralForum.Data.Entities.Thread
{
    public class PostTag : BaseEntity
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        public int TagId { get; set; }
    }
}
