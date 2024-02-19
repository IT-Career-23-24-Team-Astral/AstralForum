using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Data.Entities.Thread;

namespace AstralForum.ServiceModels
{
    public class ThreadDto : MetaBaseEntityDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public int ThreadCategoryId { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<ReactionDto> Reactions { get; set; }
        public List<ThreadAttachmentDto> Attachments { get; set; }
    }
}
