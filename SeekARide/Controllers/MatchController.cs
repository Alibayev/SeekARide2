using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using SeekARide.Models;
using SeekARide.DataAccess;

namespace SeekARide.Controllers
{
    public class MatchController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult check(string fromStreet, string fromCity, string fromState, string fromZip, string toStreet, string toCity, string toState, string toZip, string time, FormCollection fc)
        {
            string typeText = fc["typeText"];
            string origin = fromStreet + ", " + fromCity + ", " + fromState + ", " + fromZip;
            string destination = toStreet + ", " + toCity + ", " + toState + ", " + toZip;
            //Console.WriteLine("origin: " + origin);
            //Console.WriteLine("destination: " + destination);
            int type = Int32.Parse(typeText);

            ViewBag.from = origin;
            ViewBag.to = destination;
            ViewBag.time = time;
            // DriverTrip newTrip = new DriverTrip(from, to, time);
            // ViewBag.list = getResult(newTrip);
            Location from = new Location(fromStreet, fromCity, fromState, fromZip);
            Location to = new Location(toStreet, toCity, toState, toZip);
            DateTime myTime = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm",
            System.Globalization.CultureInfo.InvariantCulture);
                //.AddHours(6)

            Trip newTrip = new Trip(from, to, myTime);
            IAbstractFactory factory = MatchFactory.getInstance();
            IMatchAdapter adapter = factory.getMatchAdapter(myTime,type);
            ViewBag.list = adapter.getMatchedTrips(newTrip);


            return View();
        }

        public ActionResult SendRequest(int id)
        {
            return View();
        }
    }
}