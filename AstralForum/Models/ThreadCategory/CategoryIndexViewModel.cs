using AstralForum.Models.Categories;
using AstralForum.Models.Thread;
using AstralForum.ServiceModels;
using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.ThreadCategory
{
	public class CategoryIndexViewModel
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }
		public string Description { get; set; }
        [Display(Name = "Created by")]
        public UserDto Author { get; set; }
		public string? ImageUrl { get; set; }
		public List<CategoryThreadsViewModel> Categories { get; set; }
	}
}
