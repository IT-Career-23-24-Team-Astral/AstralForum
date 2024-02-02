using AstralForum.Models.Thread;
using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Category
{
    public class ThreadCategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
