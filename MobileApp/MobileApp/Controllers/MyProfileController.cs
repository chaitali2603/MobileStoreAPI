using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileApp.Controllers
{
    public class MyProfileController : Controller
    {
        // GET: MyProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}