using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models
{
    // The view model is the same, the id of the thread or the comment is passed as a query parameter
    public class CommentAndReplyCreationFormModel
    {
        [Required]
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
		public IEnumerable<IFormFile> Attachments { get; set; }
	}
}