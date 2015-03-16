using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Maps;

namespace WWWBewertungPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBewertung()
        {
            return View();
        }

        public ActionResult AddMap()
        {
            LatLng mainLocation = new Google.Maps.LatLng(21.622564, 87.5234417);
           // Map map = new Google.Maps.M
            return null;
        }
    }
}
