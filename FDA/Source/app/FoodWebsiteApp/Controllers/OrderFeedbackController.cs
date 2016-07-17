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
    public class OrderFeedbackController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Cancel([FromBody]EsIdRequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            OrderFeedbackService service = new OrderFeedbackService();
            StatusResponse result = new StatusResponse();
            result = service.OrderFeedBack(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
