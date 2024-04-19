using AstralForum.ServiceModels;
using AstralForum.Models.Thread;

namespace AstralForum.Models
{
    public class ThreadViewModel
    {
        public ThreadDto ThreadDto { get; set; }
        public List<ReactionTypeDto> ReactionTypeDtos { get; set; }
        public CommentAndReplyCreationFormModel CommentForm { get; set; }
        public ThreadEditFormModel ThreadEditForm { get; set; }
    }
}