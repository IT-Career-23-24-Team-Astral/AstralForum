using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AstralForum.Models.Thread
{
    public class ThreadViewModel
    {
        public int Id { get; set; }
        public int ThreadCategory { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }
}
