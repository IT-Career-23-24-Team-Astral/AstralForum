using AstralForum.Data.Entities;
using AstralForum.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;

namespace AstralForum.Controllers
{
	[ValidateAntiForgeryToken]
	public class AuthenticationController : Controller
	{
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;
		private readonly IUserStore<User> _userStore;
		private readonly IUserEmailStore<User> _emailStore;
		private readonly IEmailSender _emailSender;

		public AuthenticationController(
			UserManager<User> userManager,
			IUserStore<User> userStore,
			SignInManager<User> signInManager,
			IEmailSender emailSender)
		{
			_userManager = userManager;
			_userStore = userStore;
			_emailStore = (IUserEmailStore<User>)_userStore;
			_signInManager = signInManager;
			_emailSender = emailSender;
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromForm] UserLoginRequest loginRequest)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, loginRequest.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					return Json(new { success = true });
				}
				else
				{
					ModelState.AddModelError("Failed", "Invalid login attempt.");
				}
			}

			// will be executed if model is invalid or login has failed
			var errors = ModelState.ToDictionary(
				kvp => kvp.Key,
				kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToList()
			);
			return Json(new { success = false, errors });
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromForm] UserRegisterRequest registerRequest)
		{
			string returnUrl = Url.Content("~/");

			if (ModelState.IsValid)
			{
				var user = new User();

				user.FirstName = registerRequest.FirstName;
				user.LastName = registerRequest.LastName;

				await _userStore.SetUserNameAsync(user, registerRequest.Email, CancellationToken.None);
				await _emailStore.SetEmailAsync(user, registerRequest.Email, CancellationToken.None);
				var result = await _userManager.CreateAsync(user, registerRequest.Password);

				if (result.Succeeded)
				{
					var userId = await _userManager.GetUserIdAsync(user);
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					/*code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page(
						"/Account/ConfirmEmail",
						pageHandler: null,
						values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
						protocol: Request.Scheme);

					await _emailSender.SendEmailAsync(registerRequest.Email, "Confirm your email",
						$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
*/
					/*if (_userManager.Options.SignIn.RequireConfirmedAccount)
					{
						return RedirectToPage("RegisterConfirmation", new { email = registerRequest.Email, returnUrl = returnUrl });
					}
					else*/
					//{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return Json(new { success = true });
					//}
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("Failed", error.Description);
				}
			}

			// If we got this far, something failed, redisplay form with errors
			var errors = ModelState.ToDictionary(
				kvp => kvp.Key,
				kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToList()
			);
			return Json(new { success = false, errors });
		}
	}
}
