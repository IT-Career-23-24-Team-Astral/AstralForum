using AstralForum.ServiceModels;
using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Admin
{
	public class EditRoleViewModel
	{
		public EditRoleViewModel() 
		{
			Users = new List<string>();
		}
		public string Id { get; set; }
		[Required(ErrorMessage ="Role name is required")]
		public string RoleName { get; set; }
        public string Color { get; set; }
        public List<string> Users { get; set; }
	}
}
