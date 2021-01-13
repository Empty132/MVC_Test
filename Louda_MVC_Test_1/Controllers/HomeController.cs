using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Louda_MVC_Test_1.Models;

namespace Louda_MVC_Test_1.Controllers
{
    public class HomeController : Controller
    {
        DatabaseEntities context = new DatabaseEntities();
        public ActionResult Index()
        {
            return View(context.GPS.ToList());
        }
        public JsonResult GetMapMarker()
        {
            var ListOfAddress = context.GPS.ToList(); 

            return Json(ListOfAddress, JsonRequestBehavior.AllowGet);
        }
    }
}