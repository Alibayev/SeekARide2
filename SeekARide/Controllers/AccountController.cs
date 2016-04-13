using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SeekARide.DataAccess;
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

			}

			return View(model);

			// This doesn't count login failures towards account lockout
			// To enable password failures to trigger account lockout, change to shouldLockout: true
			//var result = 0;//await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
			//   switch (result)
			//   {
			//       case SignInStatus.Success:
			//           return RedirectToLocal(returnUrl);
			//       case SignInStatus.LockedOut:
			//           return View("Lockout");
			//       case SignInStatus.RequiresVerification:
			//           return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
			//       case SignInStatus.Failure:
			//       default:
			//           ModelState.AddModelError("", "Invalid login attempt.");
			//           return View(model);
			//   }
		}

		//



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

				CarpoolContext context = new CarpoolContext();
				context.Users.Add(user);
				try {
					context.SaveChanges();
				}catch (System.Data.Entity.Validation.DbEntityValidationException dbEx) {
				Exception raise = dbEx;
				foreach (var validationErrors in dbEx.EntityValidationErrors) {
					foreach (var validationError in validationErrors.ValidationErrors) {
						string message = string.Format("{0}:{1}",
								validationErrors.Entry.Entity.ToString(),
								validationError.ErrorMessage);
						// raise a new exception nesting
						// the current instance as InnerException
						raise = new InvalidOperationException(message, raise);
					}
				}
				throw raise;
			}
		}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//


		//
		// GET: /Account/ForgotPassword


		//
		// POST: /Account/LogOff
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff() {
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			return RedirectToAction("Index", "Home");
		}

		//
		#region Helpers
		// Used for XSRF protection when adding external logins
		private const string XsrfKey = "XsrfId";

		private IAuthenticationManager AuthenticationManager {
			get {
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		private void AddErrors(IdentityResult result) {
			foreach (var error in result.Errors) {
				ModelState.AddModelError("", error);
			}
		}

		private ActionResult RedirectToLocal(string returnUrl) {
			if (Url.IsLocalUrl(returnUrl)) {
				return Redirect(returnUrl);
			}
			return RedirectToAction("Index", "Home");
		}

		internal class ChallengeResult : HttpUnauthorizedResult {
			public ChallengeResult(string provider, string redirectUri)
					: this(provider, redirectUri, null) {
			}

			public ChallengeResult(string provider, string redirectUri, string userId) {
				LoginProvider = provider;
				RedirectUri = redirectUri;
				UserId = userId;
			}

			public string LoginProvider { get; set; }
			public string RedirectUri { get; set; }
			public string UserId { get; set; }

			public override void ExecuteResult(ControllerContext context) {
				var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
				if (UserId != null) {
					properties.Dictionary[XsrfKey] = UserId;
				}
				context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
			}
		}
		#endregion
	}
}