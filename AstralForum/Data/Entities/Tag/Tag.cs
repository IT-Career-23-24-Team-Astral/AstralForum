using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reply;
using AstralForum.Data.Entities.Thread;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstralForum.Data.Entities.Tag
{
    public class Tag : BaseEntity
    {
        public int UserId { get; set; }

        public int CommentId {  get; set; }

		[ForeignKey(nameof(Thread))]
		[Required]
		public int ThreadId { get; set; }
        public TagType TagType { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public List<Tag> Tags { get; set; }
        public List<Notification> Notifications { get; set; }

        //public ICollection<PostTag> Posts { get; set; } = new HashSet<PostTag>();

        //public ICollection<CommentTag> Comments { get; set; } = new HashSet<CommentTag>();
    }
}

