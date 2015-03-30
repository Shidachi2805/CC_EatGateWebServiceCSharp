using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Maps;
using System.IO;
using WWWBewertungPortal.Models.Datenbank;

namespace WWWBewertungPortal.Controllers
{
    public class HomeController : Controller
    {
        private WWWBewertungsModellContainer ThisContainer = new WWWBewertungsModellContainer();
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
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

                //string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                string dirpath = System.Web.HttpContext.Current.Server.MapPath("/") + "uploads";                
                string filename = System.IO.Path.GetFileName(Request.Files[upload].FileName);              
                string str_placeID = Request.Files[upload].FileName;
                string dirpathRel = "uploads/" + str_placeID;
                int  index = str_placeID.IndexOf("_EatGate_");
                str_placeID = str_placeID.Substring(0, index);

                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);
                }
                string absolutPath = System.IO.Path.Combine(dirpath, filename);
                Request.Files[upload].SaveAs(absolutPath);
                fileUploaded = true;
                var rowPlace_ID = (from lokation in ThisContainer.Tab_LokationSet
                                   where lokation.Place_id == str_placeID
                                   select lokation);
                int idLok = 0;

                foreach (var row in rowPlace_ID)
                {
                    idLok = row.Id;
                }
                try
                {
                    Tab_Lokation_Photo lokPhoto = new Tab_Lokation_Photo()
                    {
                        Uri = dirpathRel,
                        Tab_LokationId = idLok
                    };
                    ThisContainer.Tab_Lokation_PhotoSet.Add(lokPhoto);
                    ThisContainer.SaveChanges();
                    
                }
                catch (Exception ex)
                {
                    logger.Info(ex.ToString());
                    Console.WriteLine("Fehler JSON: " + ex.ToString());
                    fileUploaded = false;
                }
            }
            this.ViewData.Add("uploaded", fileUploaded);
            return View();
        }

        private bool HasFile(HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }

        public ActionResult ReadBewertung()
        {
            return View();
        }

        public ActionResult ViewPhotoDownload()
        {
            return View();
        }
		
    }
}
