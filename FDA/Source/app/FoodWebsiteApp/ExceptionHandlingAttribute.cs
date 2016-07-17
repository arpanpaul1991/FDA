using FDA.Logic.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Net.Http;
using FoodWebsiteApp.Models;

namespace FoodWebsiteApp
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.Response = context.Request.CreateResponse(
                                                                    HttpStatusCode.InternalServerError,
                                                                    ServiceResponse.CreateServiceResponse(
                                                                    ResponseBody: null,
                                                                    ResponseMessage: "Internal server error",
                                                                    ResponseError: "Exception: "
                                                                                + (context.Exception.InnerException == null ? "" : context.Exception.InnerException.ToString())
                                                                                + "\n Message: " + context.Exception.Message.ToString(),
                                                                    ResponseStatus: HttpStatusCode.InternalServerError
                                                                 )
                                                       );
            }
            if (context.Exception != null)
            {
                StringBuilder objSB = new StringBuilder();
                objSB.AppendLine("Controller : " + context.ActionContext.ControllerContext.Controller.ToString());
                objSB.AppendLine("Action : " + context.ActionContext.ActionDescriptor.ToString());
                objSB.AppendLine("Exception : " + context.Exception.Message);
                objSB.AppendLine("Inner Exception : " + (context.Exception.InnerException == null ? "" : context.Exception.InnerException.ToString()));
                objSB.AppendLine("Stack Trace : " + context.Exception.StackTrace);
                Logger.Error("Exception  - " + objSB.ToString());
            }
        }
    }
}