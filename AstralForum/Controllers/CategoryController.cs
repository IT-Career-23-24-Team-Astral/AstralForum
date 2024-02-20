using AstralForum.Models.Thread;
using AstralForum.ServiceModels;
using Microsoft.AspNetCore.Mvc;

namespace AstralForum.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index(int id)
        {
            CategoryThreadsViewModel model = new CategoryThreadsViewModel()
            {
                CategoryName = "Main category",
                CategoryId = id
            };

			List<ThreadTableViewModel> list = new List<ThreadTableViewModel>();
            ThreadTableViewModel thread = new ThreadTableViewModel()
            {
				Author = new UserDto()
				{
					Username = "Rocky47",
					DateOfCreation = DateTime.Now
				},
				DateOfCreation = DateTime.Now,
                Title = "Lorem ipsum dolor sit amet",
                LastComment = new CommentDto()
                {
                    Text = "Comment text lorem ipsum",
                    CreatedOn = DateTime.Now.AddHours(2.3),
					Author = new UserDto()
                    {
                        Username = "Rocky47",
                        DateOfCreation = DateTime.Now
					}
                }
            };
            list.Add(thread);

            model.Threads = list;

            return View(model);
        }
    }
}
