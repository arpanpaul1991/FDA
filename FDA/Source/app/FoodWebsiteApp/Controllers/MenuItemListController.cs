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
    public class MenuItemListController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage ListMenuItem([FromBody]EsIdRequest esId)
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();
            MenuItemService service = new MenuItemService();
            result = service.ShowMenuItemsService(esId);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}