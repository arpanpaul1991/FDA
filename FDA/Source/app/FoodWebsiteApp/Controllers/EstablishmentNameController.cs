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
    public class EstablishmentNameController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Index([FromBody]EsIdRequest request)
        {
            StatusResponse result = new StatusResponse();
            HttpResponseMessage response = new HttpResponseMessage();
            EstablishmentNameService service = new EstablishmentNameService();
            result = service.EstablishmentNameListService(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}