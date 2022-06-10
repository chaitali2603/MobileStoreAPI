using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace MobileApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MyProfileController : Controller
    {
        // GET: MyProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}