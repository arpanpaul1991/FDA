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
    public class EstablishmentOrderListController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage OrderList([FromBody]EsIdRequest request)
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();
            EstabslimentOrderService service = new EstabslimentOrderService();
            result = service.EstablishmentOrderListService(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
