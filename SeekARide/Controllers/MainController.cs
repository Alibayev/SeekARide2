using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeekARide.Models;

namespace SeekARide.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

	    public ActionResult AddNewPosting() {
		    return View();
	    }
		[HttpPost]
		public ActionResult AddNewPosting(NewPostingViewModel viewModel) {
			return RedirectToAction("Index");
		}
	}
}