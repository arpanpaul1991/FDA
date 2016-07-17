using FDA.Logic.Models;
using FDA.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FoodWebsiteApp.Controllers
{
    public class DeleteMenuItemController : ApiController
    {
        [System.Web.Http.HttpPost]
        public HttpResponseMessage DeleteMenuItem([FromBody]DeleteMenuItemRequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            DeleteMenuItemService service = new DeleteMenuItemService();
            StatusResponse result = new StatusResponse();
            result = service.DeleteMenu(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}