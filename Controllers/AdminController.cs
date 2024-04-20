using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models.Admin;
using AstralForum.Models.Thread;
using AstralForum.ServiceModels;
using AstralForum.Services;
using AstralForum.Services.Notification;
using AstralForum.Services.ThreadCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AstralForum.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserFacade userFacade;
        private readonly INotificationService notificationService;
        private readonly RoleManager<Role> roleManager;
		private readonly UserManager<User> userManager;
		public AdminController(IUserFacade userFacade,INotificationService notificationService, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            this.userFacade = userFacade;
            this.notificationService = notificationService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            AllUsersViewModel model = await userFacade.GetAllUsers();

            return View(model);
        }
		[Authorize(Roles = "Admin")]
		[HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
	    [Authorize(Roles = "Admin")]
		[HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            if(role == null)
            {
                return View("Error");
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
		[Authorize(Roles = "Admin")]
		[HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role
				{
                    Name = model.RoleName
                };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Admin"); 
                }
            }
            return View(model);
        }
	    [Authorize(Roles = "Admin")]
		[HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
		[Authorize(Roles = "Admin")]
		[HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return View("Error");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id.ToString(),
                RoleName = role.Name
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
		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> EditRole(EditRoleViewModel model)
		{
			var role = await roleManager.FindByIdAsync(model.Id);
			if (role == null)
			{
				return View("Error");
			}
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                else
                {
					return View("Error");
				}
            }
		}
		[Authorize(Roles = "Admin")]
		[HttpGet]
        public async Task<IActionResult> EditUsersInRole(string id)
        {
            ViewBag.id = id;
            var role = await roleManager.FindByIdAsync(id);
			if (role == null)
			{
				return View("Error");
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
		[Authorize(Roles = "Admin")]
		[HttpPost] 
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string id)
        {
            var role = await roleManager.FindByIdAsync(id);
			if (role == null)
			{
				return View("Error");
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
	}
}
