using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models
{
    public class ThreadCategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
   