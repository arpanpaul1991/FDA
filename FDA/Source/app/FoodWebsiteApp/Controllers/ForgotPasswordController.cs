using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FDA.Logic.Services;
using FDA.Logic.Models;

namespace FoodWebsiteApp.Controllers
{
    public class ForgotPasswordController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage ForgotPasswordRequest([FromBody]ForgotPasswordRequest request)
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();
            UserService service = new UserService();
            result = service.ForgotPasswordService(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);

            return response;
        }
    }
}