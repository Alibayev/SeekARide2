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
using SeekARide.Authorization;
using SeekARide.DataAccess.Repository;

namespace SeekARide.Controllers
{
    public class RequestController : Controller
    {
        CarpoolContext db = new CarpoolContext();
        // GET: Request
        public ActionResult Index()
        {
            RequestRepository repo = new RequestRepository();
            //Pass owner and user id
            User user = UserAccountsManager.Instance.CurrentUser;
            ViewBag.list = repo.GetByOwnerId(user.UserId);
            ViewBag.list1 = repo.GetByUserId(user.UserId);
            return View();
        }

        public ActionResult Accept(int? id, int? tripinfoid)
        {
            //Update requests
            RequestRepository reqRepo = new RequestRepository();
            Request request = reqRepo.GetById(id);

            request.Response = 1;

            reqRepo.UpdateRequest(request);

            //Update trip information
            TripInformationRepository tripInfoRepo = new TripInformationRepository();
            TripInformation tripInfo = tripInfoRepo.GetById(tripinfoid);
            tripInfo.Users.Add(request.User);
            tripInfo.Capacity--;

            //Added instead of update repo
            string sql = "update TripInformation set Capacity=@P0 where TripInformationId=@P1";
            List<object> parameterList1 = new List<object>();
            //User user = (User)Session["__user"];
            parameterList1.Add(tripInfo.Capacity);
            parameterList1.Add(tripInfo.TripInformationId);
            object[] parameters1 = parameterList1.ToArray();
            int result = db.Database.ExecuteSqlCommand(sql, parameters1);


            //tripInfoRepo.UpdateTripInformation(tripInfo);//Error when executing this line
            
            

            return RedirectToAction("Index", "Request");
        }

        public ActionResult Deny(int? id, int? tripinfoid)
        {

            //Update requests
            RequestRepository reqRepo = new RequestRepository();
            Request request = reqRepo.GetById(id);

            request.Response = 2;

            reqRepo.UpdateRequest(request);

            
            return RedirectToAction("Index", "Request");
        }

        

        
    }
}


   




