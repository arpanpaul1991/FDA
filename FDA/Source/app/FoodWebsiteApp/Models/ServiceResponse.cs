using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.ComponentModel;
using System.Runtime.Serialization;
using FDA.Logic.Models;


namespace FoodWebsiteApp.Models
{
    //[KnownType(typeof(Role))]
    //[KnownType(typeof(RolePermissions))]
    //[KnownType(typeof(RoleWithUserCount))]
    //[KnownType(typeof(Permission))]
    //[KnownType(typeof(System.Dynamic.ExpandoObject))]
    //[KnownType(typeof(DownSyncResponse))]
    //[KnownType(typeof(PermissionGroup))]
    public class ServiceResponse
    {
        public int Status
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public string Error
        {
            get;
            set;
        }
        public object Body
        {
            get;
            set;
        }

        public ServiceResponse() { }

        public static ServiceResponse CreateServiceResponse(object ResponseBody, string ResponseMessage, string ResponseError = "", HttpStatusCode ResponseStatus = HttpStatusCode.OK)
        {
            return new ServiceResponse()
            {
                Body = ResponseBody,
                Message = ResponseMessage,
                Error = ResponseError,
                Status = (int)ResponseStatus
            };

        }
    }


}