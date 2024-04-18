using AstralForum.ServiceModels;
using AstralForum.Models.Comment;
using System.Collections.Generic;

namespace AstralForum.Models
{
    public class ThreadViewModel
    {
        public ThreadDto ThreadDto { get; set; }
        public List<ReactionTypeDto> ReactionTypeDtos { get; set; }
        public CommentAndReplyCreationFormModel CommentForm { get; set; }
    }
}