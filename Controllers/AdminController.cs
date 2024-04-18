using AstralForum.Data.Entities;
using AstralForum.Models.Admin;
using AstralForum.Repositories;
using AstralForum.Services;
using AstralForum.Services.Comment;
using AstralForum.Services.Thread;
using AstralForum.Services.ThreadCategory;
using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using System;

namespace AstralForum.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserFacade userFacade;
        private readonly ICommentFacade commentFacade;
        private readonly ICommentService commentService;
        private readonly RoleManager<Role> roleManager;
		private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IThreadFacade threadFacade;
        private readonly IThreadService threadService;
        private readonly ThreadRepository threadRepository;
        private readonly ApplicationDbContext applicationDbContext;
        public AdminController(IUserFacade userFacade, RoleManager<Role> roleManager, UserManager<User> userManager, IThreadFacade threadFacade, IThreadService threadService, ThreadRepository threadRepository, ApplicationDbContext applicationDbContext, ICommentFacade commentFacade, ICommentService commentService, SignInManager<User> signInManager)
        {
            this.userFacade = userFacade;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.threadFacade = threadFacade;
            this.threadService = threadService;
            this.threadRepository = threadRepository;
            this.applicationDbContext = applicationDbContext;
            this.commentFacade = commentFacade;
            this.commentService = commentService;
            this.signInManager = signInManager;
        }
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            AllUsersViewModel model = await userFacade.GetAllUsers();

            return View(model);
        }
		//[Authorize(Roles = "Admin")]
		[HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role
                {
                    Name = model.RoleName,
                    Color = model.Color
                };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Admin");
                }
            }
            return View(model);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            if(role == null)
            {
                return NotFound();                                                            
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                return View("ListRoles");
            }
        }
		
	    //[Authorize(Roles = "Admin")]
		[HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
		//[Authorize(Roles = "Admin")]
		[HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id.ToString(),
                RoleName = role.Name,
                Color = role.Color,
            };
			foreach (var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }
		//[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> EditRole(EditRoleViewModel model)
		{
			var role = await roleManager.FindByIdAsync(model.Id);
			if (role == null)
			{
				return NotFound();
			}
            else
            {
                role.Name = model.RoleName;
                role.Color = model.Color;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                else
                {
					return NotFound();
                }
            }
		}
		//[Authorize(Roles = "Admin")]
		[HttpGet]
        public async Task<IActionResult> EditUsersInRole(string id)
        {
            ViewBag.id = id;
            var role = await roleManager.FindByIdAsync(id);
			if (role == null)
			{
				return NotFound();
            }
            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
					userRoleViewModel.IsSelected = true;
				}
                else
                {
                    userRoleViewModel.IsSelected = false;
				}
                model.Add(userRoleViewModel);
			}
            return View(model);
		}
		//[Authorize(Roles = "Admin")]
		[HttpPost] 
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string id)
        {
            var role = await roleManager.FindByIdAsync(id);
			if (role == null)
			{
				return NotFound();
            }
            for(int i = 0; i < model.Count; i++)
            {
				var user = await userManager.FindByIdAsync(model[i].UserId.ToString());
				IdentityResult result = null;
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
				{
					result = await userManager.RemoveFromRoleAsync(user, role.Name);
				}
                else
                {
                    continue;
                }
                if (result.Succeeded) 
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else 
                    { 
                        return RedirectToAction("EditRole", new {Id = role.Id}); 
                    }
                }
            }
            return RedirectToAction("EditRole", new { Id = id});
		}
        [HttpGet]
        public async Task<IActionResult> Ban(int id)
        {
            var user = await applicationDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.IsBanned = true;
            await applicationDbContext.SaveChangesAsync();
            await userManager.UpdateSecurityStampAsync(user);
            //await signInManager.SignOutAsync();
            string returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
        }
        [HttpGet]
        public async Task<IActionResult> Unban(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await applicationDbContext.Users.FindAsync(id);
            user.IsBanned = false;
            await applicationDbContext.SaveChangesAsync();
            string returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
        }
        public async Task<IActionResult> TimeOut(int id, DateTime time)
        {
            var user = await applicationDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(); 
            }
            DateTime maxTimeOut = DateTime.Now.AddHours(24);
            if (time > maxTimeOut)
            {
                return BadRequest("Time exceeds maximum allowed 24 hours timeout.");
            }
            user.TimeOut = time;
            await applicationDbContext.SaveChangesAsync();
            string returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
        }
        //  Timed out for @((item.TimeOut - DateTime.Now).TotalHours.ToString("0")) hours and @((item.TimeOut - DateTime.Now).Minutes) minutes
        public async Task<IActionResult> DeleteTimeout(int id)
        {
            var user = await applicationDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.TimeOut = DateTime.Now;
            await applicationDbContext.SaveChangesAsync();
            string returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
        }
        [HttpGet]
        public async Task<IActionResult> HiddenThreads()
        {
            HiddenThreadsViewModel model = await threadFacade.GetAllHiddenThreads();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteThread(int id)
        {
            var thread = threadService.DeleteThread(id);

            return RedirectToAction("HiddenThreads");
        }
        [HttpGet]
        public async Task<IActionResult> RecoverThread(int id)
        {
            var thread = threadService.GetDeletedThreadBack(id);

            string returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAllThreadsAndCommentsByUserId(int userid)
        {
            threadService.DeleteAllThreadsByUserId(userid);
            commentService.DeleteAllCommentsByUserId(userid);
            string returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
        }
        [HttpGet]
        public async Task<IActionResult> DeletedThreads()
        {
            HiddenThreadsViewModel model = await threadFacade.GetAllDeletedThreads();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> HiddenComments()
        {
            HiddenCommentsViewModel model = await commentFacade.GetAllHiddenComments();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = commentService.DeleteComment(id);

            string returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
        }
        [HttpGet]
        public async Task<IActionResult> RecoverComment(int id)
        {
            var comment = commentService.GetDeletedCommentBack(id);

            string returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
        }
        [HttpGet]
        public async Task<IActionResult> DeletedComments()
        {
            HiddenCommentsViewModel model = await commentFacade.GetAllDeletedComments();

            return View(model);
        }
    }
}
