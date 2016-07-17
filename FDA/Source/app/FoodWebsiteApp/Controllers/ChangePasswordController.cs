using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FDA.Logic.Models;
using FDA.Core.UnitOfWork;
using FDA.Logic.Services;

namespace FoodWebsiteApp.Controllers
{
   
    public class ChangePasswordController : ApiController
    {
        // GET api/<controller>
         [HttpPost]
        public HttpResponseMessage Details([FromBody]ChangePasswordRequest request)
        {
            StatusResponse result=new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();
            UserService service = new UserService();
            result = service.ChangePasswordService(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);

            return response;
        }
    }
}