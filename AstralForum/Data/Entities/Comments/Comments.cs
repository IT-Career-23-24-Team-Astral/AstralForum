namespace AstralForum.Data.Entities.Comments
{
    public class Comments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int? CommentId { get; set; }
    }
}
