namespace AstralForum.Data.Entities.Thread
{
    public class Post : MetadataBaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public int ThreadCategory { get; set; }
    }
}
