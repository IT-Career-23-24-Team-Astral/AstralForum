using AstralForum.Data.Entities;

namespace AstralForum.Data.Entities.Thread
{
    public class Thread : MetadataBaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public ThreadCategory.ThreadCategory ThreadCategory { get; set; }
        public int ThreadCategoryId { get; set; }
        public List<Comment.Comment> Comments { get; set; }
        public List<Reaction.Reaction> Reactions { get; set; }
        public List<ThreadAttachment> Attachments { get; set; }
    }
}
