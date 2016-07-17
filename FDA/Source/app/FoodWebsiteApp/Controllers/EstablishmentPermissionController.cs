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
    public class EstablishmentPermissionController : ApiController
    {
        // GET: EstablishmentPermission
        [System.Web.Http.HttpPost]
        public HttpResponseMessage ChangePermission([FromBody]EstablishmentPermissionrequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ApproveEstablishmentService service = new ApproveEstablishmentService();
            StatusResponse result = new StatusResponse();
            result = service.ApproveEstablishment(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;

        }
    }
}