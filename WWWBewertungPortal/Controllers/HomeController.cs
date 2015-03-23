using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Maps;
using System.IO;

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

        public ActionResult AddLokation()
        {
            return View();
        }
        public ActionResult PhotoUpload()
        {
            var fileUploaded = false;
            foreach (string upload in Request.Files)
            {
                if (!HasFile(Request.Files[upload]))
                    continue;

                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                string filename = System.IO.Path.GetFileName(Request.Files[upload].FileName);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Request.Files[upload].SaveAs(System.IO.Path.Combine(path, filename));
                fileUploaded = true;
            }
            this.ViewData.Add("uploaded", fileUploaded);
            return View();
        }

        private bool HasFile(HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }

        public ActionResult AddMap()
        {
            LatLng mainLocation = new Google.Maps.LatLng(21.622564, 87.5234417);
           // Map map = new Google.Maps.M
            return null;
        }
    }
}
