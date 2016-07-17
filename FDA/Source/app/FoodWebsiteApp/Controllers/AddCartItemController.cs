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
    public class AddCartItemController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage AddItem([FromBody]CartAddItemRequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            CartService service = new CartService();
            StatusResponse result = new StatusResponse();
            result = service.AddItem(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
