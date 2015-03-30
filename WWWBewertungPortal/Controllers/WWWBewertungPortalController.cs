using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WWWBewertungPortal.Models.Datenbank;
using WWWBewertungPortal.Services;

namespace WWWBewertungPortal.Controllers
{
    public class WWWBewertungPortalController : ApiController
    {
        private WWWBewertungPortalRepository wwwBewertungPortalRepository;

        public WWWBewertungPortalController()
        {
            this.wwwBewertungPortalRepository = new WWWBewertungPortalRepository();
        }

        private HttpResponseMessage benutzerPost(JObject data)
        {          
            this.wwwBewertungPortalRepository.SaveBenutzer(data);
            var response = Request.CreateResponse<JObject>(System.Net.HttpStatusCode.Created, data);
            return response;
        }

        private HttpResponseMessage bewertungPost(JObject data)
        {
            this.wwwBewertungPortalRepository.SaveBewertung(data);
            var response = Request.CreateResponse<JObject>(System.Net.HttpStatusCode.Created, data);
            return response;
        }

        private HttpResponseMessage lokationPost(JObject data)
        {
            this.wwwBewertungPortalRepository.SaveLokation(data);
            var response = Request.CreateResponse<JObject>(System.Net.HttpStatusCode.Created, data);
            return response;
        }

        private HttpResponseMessage bewertungReadPost(JObject data)
        {
            JArray job =  this.wwwBewertungPortalRepository.ReadBewertung(data);
            var response = Request.CreateResponse<JArray>(System.Net.HttpStatusCode.Created, job);
            return response;
        }
        private HttpResponseMessage downloadPhoto(JObject data)
        {
            JArray job = this.wwwBewertungPortalRepository.DownloadPhoto(data);
            var response = Request.CreateResponse<JArray>(System.Net.HttpStatusCode.Created, job);
            return response;
        }
        public HttpResponseMessage Post(JObject data)
        {
            string service = (string)data.GetValue("Service");
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("HTTP_POST");
            if (service == null)
            {
                return null;
            }
            if (service.Equals("AddBewertung"))
            {
                logger.Info("HTTP_POST AddBewertung");
                return bewertungPost(data);
            }
            if (service.Equals("AddBenutzer"))
            {
                logger.Info("HTTP_POST Benutzer");
                return benutzerPost(data);
            }
            if (service.Equals("AddLokation"))
            {
                logger.Info("HTTP_POST AddLokation");
                return lokationPost(data);
            }
            if(service.Equals("ReadBewertungen"))
            {
                logger.Info("Lesen Von DB");
                return bewertungReadPost(data);
            }
            if (service.Equals("ViewPhotoDownload"))
            {
                logger.Info("Holen Von DB");
                return downloadPhoto(data);
            }

            return null;
        }

        

        

        //public HttpResponseMessage Post(JObject data)
        //{


        //    this.wwwBewertungPortalRepository.SaveBewertung(data);
        //    var response = Request.CreateResponse<JObject>(System.Net.HttpStatusCode.Created, data);
        //    return response;
        //}


    }
}
