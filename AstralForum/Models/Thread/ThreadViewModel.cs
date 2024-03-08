using AstralForum.ServiceModels;

namespace AstralForum.Models
{
    public class ThreadViewModel
    {
        public ThreadDto ThreadDto { get; set; }
        public CommentAndReplyCreationFormModel CommentForm { get; set; }
    }
}