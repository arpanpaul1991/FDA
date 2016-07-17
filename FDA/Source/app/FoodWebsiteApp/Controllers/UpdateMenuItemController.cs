using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using FDA.Logic.Models;
using FDA.Core.UnitOfWork;
using FDA.Logic.Services;
using System.Web;
using System.Web.Http;

namespace FoodWebsiteApp.Controllers
{
    public class UpdateMenuItemController : ApiController
    {
        // GET: UpdateMenuItems
       [HttpPost]
        public HttpResponseMessage UpdateMenuItems([FromBody]EditMenuItemRequest request)
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();
            MenuItemService service = new MenuItemService();
            result = service.UpdateMenuItemService(request);

            response = Request.CreateResponse(HttpStatusCode.OK, result);

            return response;
        }
    }
}