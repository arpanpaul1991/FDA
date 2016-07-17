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
    public class SellerListController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage SellerList()
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();
            SellerService service = new SellerService();
            result = service.SellerListService();
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}