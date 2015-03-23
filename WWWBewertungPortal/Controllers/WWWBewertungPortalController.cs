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

        public HttpResponseMessage Post(JObject data)
        {
            string service = (string)data.GetValue("Service");

            if (service == null)
            {
                return null;
            }
            if (service.Equals("AddBewertung"))
            {
                return bewertungPost(data);
            }
            if (service.Equals("AddBenutzer"))
            {
                return benutzerPost(data);
            }
            if (service.Equals("AddLokation"))
            {
                return lokationPost(data);
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
