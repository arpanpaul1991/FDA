using FDA.Logic.Models;
using FDA.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodWebsiteApp.Controllers
{
    public class AddOneCartItemController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddOneItem([FromBody]CartIdRequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            CartService service = new CartService();
            StatusResponse result = new StatusResponse();
            result = service.AddOneItem(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
