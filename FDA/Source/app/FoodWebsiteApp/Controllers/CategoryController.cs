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
    public class CategoryController : ApiController
    {
        // GET: Category
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Category()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            CategoryListService service = new CategoryListService();
            StatusResponse result = new StatusResponse();
            result = service.CategoryList();
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}