using AstralForum.ServiceModels;
using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Thread
{
	public class ThreadTableViewModel
	{
        public int Id { get; set; }

        [Display(Name = "Title")]
		public string Title { get; set; }

		[Display(Name = "Date of creation")]
		public DateTime DateOfCreation { get; set; }

		[Display(Name = "Created by")]
		public UserDto Author { get; set; }

		[Display(Name = "Last comment")]
		public CommentDto LastComment { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDeleted { get; set; } 
    }
}