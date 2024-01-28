using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
