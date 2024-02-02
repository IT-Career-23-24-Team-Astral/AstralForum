using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Category
{
    public class ThreadCategoryFormModel
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public int CreatedById { get; set; }
    }
}
