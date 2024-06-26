﻿using AstralForum.Data.Entities;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models.Categories;
using AstralForum.Models.Thread;
using AstralForum.Models.ThreadCategory;
using AstralForum.ServiceModels;
using AstralForum.Services;
using AstralForum.Services.Thread;
using AstralForum.Services.ThreadCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Collections.Generic;
using System.Net.Sockets;

namespace AstralForum.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IThreadCategoryFacade threadCategoryFacade;
        private readonly IThreadService threadService;
        private readonly UserManager<User> userManager;
        public CategoryController(IThreadCategoryFacade threadFacade, IThreadService threadService, UserManager<User> userManager)
        {
            this.threadCategoryFacade = threadFacade;
            this.threadService = threadService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            CategoryViewModel categoryViewModel = threadCategoryFacade.GetAllThreadCategories();
            return View(categoryViewModel);
        }

        [Authorize]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CategoryCreateViewModel threadCategoryForm)
        {
            User loggedInUser = await userManager.GetUserAsync(User);

            await threadCategoryFacade.CreateThreadCategory(threadCategoryForm, loggedInUser);

            return RedirectToAction("Index", "Category", new { id = threadCategoryForm.CategoryId });
        }

        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            // TODO: find a better way to handle getting thread category data
            CategoryThreadsViewModel categoryModel = threadCategoryFacade.GetAllThreadsByCategoryId(id);

            CategoryIndexViewModel model = new CategoryIndexViewModel()
            {
                CategoryId = id,
                CategoryName = categoryModel.CategoryName,
                Description = categoryModel.Description
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(CategoryIndexViewModel threadCategoryForm)
        {
            await threadCategoryFacade.EditThreadCategory(threadCategoryForm, await userManager.GetUserAsync(User));

            return RedirectToAction("Specify", "Category", new { id = threadCategoryForm.CategoryId });
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            CategoryIndexViewModel model = new CategoryIndexViewModel()
            {
                CategoryId = id
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
		[Authorize(Roles = "Admin, Moderator")]
		[HttpGet]
        public IActionResult HideThread(int id)
        {
            var thread = threadService.HideThread(id);

			string returnUrl = HttpContext.Request.Headers["Referer"];
			return Redirect(returnUrl);
		}
        public IActionResult NoResults()
        {
            if (TempData["CategoryId"] == null)
            {
                return RedirectToAction("Index", "Category");
            }
            int id = (int)TempData["CategoryId"];
            CategoryThreadsViewModel model = threadCategoryFacade.NoResults(id);
            return View(model);
        }
    }
}