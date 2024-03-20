using AstralForum.ServiceModels;

namespace AstralForum.Models.Admin
{
    public class AllHiddenThreadsViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public UserDto CreatedBy { get; set; }
    }
}
