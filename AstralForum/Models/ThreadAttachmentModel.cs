using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models
{
    public class ThreadAttachmentModel
    {
        public int Id { get; set; }
        [Required]
        public int ThreadId { get; set; }
        [Required]
        public string AttachmentUrl { get; set; }
    }
}
