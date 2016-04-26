using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeekARide.Models;

namespace SeekARide.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Payment(PaymentViewModel Model)
        {
            if (ModelState.IsValid)
            {

                ViewBag.status = "Payment successfull !";
                // Payment pay = new Payment();
                // pay.Amount = pay.Amount - Model.Amount;

            }
            else
            {

            }

            return View();
        }
    }
}