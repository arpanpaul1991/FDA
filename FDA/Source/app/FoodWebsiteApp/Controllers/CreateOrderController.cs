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
    public class CreateOrderController : ApiController
    {
        // GET api/<controller>
        [HttpPost]
        public HttpResponseMessage OrderRequest([FromBody]CreateOrderRequest request)
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();
            CreateOrderService service = new CreateOrderService();
            result = service.CreateOrder(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}