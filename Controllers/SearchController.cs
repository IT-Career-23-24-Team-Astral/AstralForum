using AstralForum.Data.Entities;
using AstralForum.Models.Admin;
using AstralForum.Models.Thread;
using AstralForum.Models.ThreadCategory;
using AstralForum.Services;
using AstralForum.Services.ThreadCategory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstralForum.Controllers
{
    public class SearchController : Controller
    {
        private readonly IThreadCategoryFacade threadCategoryFacade;
        private readonly UserManager<User> userManager;
        public SearchController(IThreadCategoryFacade threadCategoryFacade, UserManager<User> userManager)
        {
            this.threadCategoryFacade = threadCategoryFacade;
            this.userManager = userManager;
        }
        
        public IActionResult Search(string searchQuery)
        {
            ViewData["CurrentFilter"] = searchQuery;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                CategoryViewModel categoryViewModel = threadCategoryFacade.SearchThreadCategoriesByBoth(searchQuery);
                return View("~/Views/Category/Index.cshtml", categoryViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }
        }

        public IActionResult SearchCategoryName(string searchQuery)
        {
            ViewData["CurrentFilter"] = searchQuery;


            if (!string.IsNullOrEmpty(searchQuery))
            {
                CategoryViewModel categoryViewModel = threadCategoryFacade.SearchThreadCategoriesByName(searchQuery);
                return View("~/Views/Category/Index.cshtml", categoryViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }
        }

        public IActionResult SearchCreatedBy(string searchQuery)
        {
            ViewData["CurrentFilter"] = searchQuery;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                CategoryViewModel categoryViewModel = threadCategoryFacade.SearchThreadCategoriesByCreatedBy(searchQuery);
                return View("~/Views/Category/Index.cshtml", categoryViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }
        }
        public IActionResult SearchThread(int id, string searchQuery)
        {
            ViewData["CurrentFilter"] = searchQuery;
            CategoryThreadsViewModel model = threadCategoryFacade.SearchThreadByTitle(id, searchQuery);
            if (model == null)
            {
                TempData["CategoryId"] = id; 
                return RedirectToAction("NoResults", "Category");
            }
            else if (!string.IsNullOrEmpty(searchQuery))
            {
                return View("~/Views/Category/Specify.cshtml", model);
            }
            else if (string.IsNullOrEmpty(searchQuery))
            {
                TempData["CategoryId"] = id;
                return RedirectToAction("NoResults", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }
        }
        public IActionResult SearchThreadByCreatedBy(int id, string searchQuery)
        {
            ViewData["CurrentFilter"] = searchQuery;
            CategoryThreadsViewModel model = threadCategoryFacade.SearchThreadByCreatedBy(id, searchQuery);

            if (model == null)
            {
                TempData["CategoryId"] = id; 
                return RedirectToAction("NoResults", "Category");
            }
            else if (!string.IsNullOrEmpty(searchQuery))
            {
                return View("~/Views/Category/Specify.cshtml", model);
            }
            else if (string.IsNullOrEmpty(searchQuery))
            {
                TempData["CategoryId"] = id;
                return RedirectToAction("NoResults", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }
        }
    }
}
    
