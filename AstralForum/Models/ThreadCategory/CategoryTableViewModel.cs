using AstralForum.ServiceModels;
using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Categories
{
	public class CategoryTableViewModel
	{
		public int Id { get; set; }
        [Display(Name = "Title")]
        public string CategoryName { get; set; }
		public string Description { get; set; }
       
        [Display(Name = "Date of creation")]
        public DateTime DateOfCreation { get; set; }

        [Display(Name = "Created by")]
        public UserDto Author { get; set; }
        public string ImageUrl { get; set; }

    }
}
