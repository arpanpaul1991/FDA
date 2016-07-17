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
    public class UpdateOrderController : ApiController
    {
        // GET api/<controller>
        [HttpPost]
        public HttpResponseMessage Update([FromBody]UpdateOrderRequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            UpdateOrderService service = new UpdateOrderService();
            StatusResponse result = new StatusResponse();
            result = service.UpdateOrder(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}