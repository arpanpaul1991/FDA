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
    public class CreateMenuItemController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddMenuItemRequest([FromBody]AddMenuItemRequest request)
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();

            MenuItemService service = new MenuItemService();
            result = service.AddMenuItem(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
