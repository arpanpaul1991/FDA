﻿using FDA.Logic.Models;
using FDA.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodWebsiteApp.Controllers
{
    public class RemoveCartItemController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage RemoveItem([FromBody]CartIdRequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            CartService service = new CartService();
            StatusResponse result = new StatusResponse();
            result = service.RemoveItem(request);
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
