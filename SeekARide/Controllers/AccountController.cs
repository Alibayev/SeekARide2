using System.Web.Mvc;
using SeekARide.Authorization;
using SeekARide.Models;

namespace SeekARide.Controllers {
	[Authorize]
	public class AccountController : Controller {

		public AccountController() {
		}

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login(string returnUrl) {
			if (UserAccountsManager.Instance.CurrentUser != null) {
				UserAccountsManager.Instance.SignOut();
				return RedirectToAction("Index", "Home");
			}
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		//
		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel model, string returnUrl) {

			if (!ModelState.IsValid) {
				return View(model);
			}

			UserAccountsManager.Instance.Login(model.Email, model.Password);
			return RedirectToAction("Index", "Main");
		}

		//
		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult Register() {
			return View();
		}

		//
		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterViewModel model) {
			if (ModelState.IsValid) {
				User user = new User();
				user.FirstName = model.FirstName;
				user.LastName = model.LastName;
				user.Email = model.Email;
				user.Password = model.Password;
				UserAccountsManager.Instance.Register(user);
			}
		

			// If we got this far, something failed, redisplay form
			return RedirectToAction("Login", "Account");
		}

		[ValidateAntiForgeryToken]
		public ActionResult LogOff() {
			UserAccountsManager.Instance.SignOut();
			return RedirectToAction("Index", "Home");
		}
	
	}
}