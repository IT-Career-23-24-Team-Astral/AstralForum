using AstralForum.Data.Entities;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models.Categories;
using AstralForum.Models.Thread;
using AstralForum.Models.ThreadCategory;
using AstralForum.ServiceModels;
using AstralForum.Services;
using AstralForum.Services.ThreadCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Collections.Generic;

namespace AstralForum.Controllers
{
    public class CategoryController : Controller
    {
        /*public IActionResult Index(int id)
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
        }*/

        /*private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            this._db = db;
        }*/
        private readonly IThreadCategoryFacade threadCategoryFacade;
        private readonly IThreadCategoryService threadCategoryService;
        private readonly UserManager<User> userManager;
        public CategoryController(IThreadCategoryFacade threadFacade, IThreadCategoryService threadCategoryService, UserManager<User> userManager)
        {
            this.threadCategoryFacade = threadFacade;
            this.threadCategoryService = threadCategoryService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            CategoryViewModel categoryViewModel = threadCategoryFacade.GetAllThreadCategories();
            return View(categoryViewModel);
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            CategoryCreateViewModel model = new CategoryCreateViewModel()
            {
                CategoryId = id
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(CategoryCreateViewModel threadCategoryForm)
        {
            User loggedInUser = await userManager.GetUserAsync(User);

            await threadCategoryFacade.CreateThreadCategory(threadCategoryForm, loggedInUser);

            return RedirectToAction("Index", "Category", new { id = threadCategoryForm.CategoryId });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            CategoryIndexViewModel model = new CategoryIndexViewModel()
            {
                CategoryId = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryIndexViewModel threadCategoryForm)
        {
            await threadCategoryFacade.EditThreadCategory(threadCategoryForm, await userManager.GetUserAsync(User));

            return RedirectToAction("Specify", "Category", new { id = threadCategoryForm.CategoryId });
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            CategoryIndexViewModel model = new CategoryIndexViewModel()
            {
                CategoryId = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryIndexViewModel threadCategoryForm)
        {
            await threadCategoryFacade.DeleteThreadCategory(threadCategoryForm, await userManager.GetUserAsync(User));

            return RedirectToAction("Index", "Category", new { id = threadCategoryForm.CategoryId });
        }

        public IActionResult Specify(int id)
        {
            CategoryThreadsViewModel model = threadCategoryFacade.GetAllThreadsByCategoryId(id);

            return View(model);
        }
    }
}