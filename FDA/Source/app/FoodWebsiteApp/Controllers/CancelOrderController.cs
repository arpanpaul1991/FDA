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
    public class CancelOrderController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Cancel([FromBody]CancelOrderRequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            CancelOrderService service = new CancelOrderService();
            StatusResponse result = new StatusResponse();
            result = service.CancelOrder(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
