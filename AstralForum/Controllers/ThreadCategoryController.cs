using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstralForum.Controllers
{
    public class ThreadCategoryController : Controller
    {
        // GET: ThreadCategoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ThreadCategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThreadCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThreadCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ThreadCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ThreadCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ThreadCategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ThreadCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
