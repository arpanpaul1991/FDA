using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
   public class StatusResponse
    {
       
            public int Status { get; set; }
            public string StatusMessage { get; set; }
            public string ResponseMessage { get; set; }
            public object Body { get; set; }
    }
}
