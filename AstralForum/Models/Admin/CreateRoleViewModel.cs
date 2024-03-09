using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Admin
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
