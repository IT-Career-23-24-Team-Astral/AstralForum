using AstralForum.Data.Entities;
using AstralForum.Models.Reaction;
using AstralForum.ServiceModels;
using AstralForum.Services.Reaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AstralForum.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ReactionTypeController : Controller
    {
        private readonly IReactionService reactionService;
        private readonly IReactionFacade reactionFacade;
        private readonly UserManager<User> userManager;

        public ReactionTypeController(IReactionService reactionService, IReactionFacade reactionFacade, UserManager<User> userManager)
        {
            this.reactionService = reactionService;
            this.reactionFacade = reactionFacade;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ReactionTypeDto> reactionTypeDtos = await reactionService.GetAllReactionTypes();
            return View("Index", reactionTypeDtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

		[HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ReactionTypeCreationFormModel reactionType)
		{
            await reactionFacade.AddReactionType(reactionType, await userManager.GetUserAsync(User));
			return RedirectToAction("Index");
		}

		[HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await reactionService.DeleteReactionTypeById(id);
			List<ReactionTypeDto> reactionTypeDtos = await reactionService.GetAllReactionTypes();
			return RedirectToAction("Index");
		}
    }
}
