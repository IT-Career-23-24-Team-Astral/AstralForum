namespace AstralForum.Data.Entities.Thread
{
    public class Thread : MetadataBaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public int ThreadCategoryId { get; set; }
        public List<Comment.Comment> Comments { get; set; }
        public List<Reaction.Reaction> Reactions { get; set; }
    }
}
