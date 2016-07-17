using FDA.Logic.Models;
using FDA.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FoodWebsiteApp.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Details([FromBody]LoginRequest request)
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();

            LoginService service = new LoginService();
            result = service.AutheticationService(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);

            return response;
        }
    }
}