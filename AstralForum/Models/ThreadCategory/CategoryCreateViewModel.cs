using AstralForum.Models.Thread;
using AstralForum.Models.ThreadCategory;

namespace AstralForum.Models.Categories
{
    public class CategoryCreateViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
		public IEnumerable<CategoryIndexViewModel> Categories { get; set; }
	}
}
