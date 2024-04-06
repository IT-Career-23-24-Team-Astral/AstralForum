using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Data.Entities.Thread;

namespace AstralForum.ServiceModels
{
    public class ThreadDto : MetaBaseEntityDto
    {
        public ThreadDto() {
            Comments = new List<CommentDto>();
            Reactions = new List<ReactionDto>();
            Attachments = new List<ThreadAttachmentDto>();
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public int ThreadCategoryId { get; set; }
        public string ThreadCategoryName { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<ReactionDto> Reactions { get; set; }
        public List<ThreadAttachmentDto> Attachments { get; set; }
        public bool IsHidden { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
