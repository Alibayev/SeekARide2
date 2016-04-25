using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeekARide.Authorization;
using SeekARide.DataAccess.Repository;
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
			TripRepository tripRepository = new TripRepository();
			tripRepository.AddTrip(viewModel, UserAccountsManager.Instance.CurrentUser);
			return RedirectToAction("Index");
		}

	    public ActionResult ShowAddressBook() {
		    User user = UserAccountsManager.Instance.CurrentUser;
				AddressBook addressBook = new Repository<AddressBook>().GetById(user.UserId);
		    return PartialView(addressBook.Locations);
	    }

	    public ActionResult _GetAllActiveTripsPartial() {
			TripRepository repo = new TripRepository();
		    IList<Trip> activeTrips = repo.GetAllActiveTrips();
		    return PartialView(activeTrips);
	    }
	}
}