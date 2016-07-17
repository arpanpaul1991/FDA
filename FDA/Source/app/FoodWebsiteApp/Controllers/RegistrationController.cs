using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using FDA.Logic.Models;
using FDA.Core.UnitOfWork;
using FDA.Logic.Services;
using System.Web;
//using System.Web.Mvc;
using System.Web.Http;

namespace FoodWebsiteApp.Controllers
{
    public class RegistrationController : ApiController
    {
        [HttpPost]

        public HttpResponseMessage Details([FromBody]RegistrationRequest request)
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();
            RegistrationService service = new RegistrationService();
            result = service.Registration(request);
            
            response = Request.CreateResponse(HttpStatusCode.OK, result);

            return response;
        }
    }
}