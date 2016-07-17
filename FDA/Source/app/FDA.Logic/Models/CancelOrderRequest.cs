using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class CancelOrderRequest
    {
        public int OrderId { get; set; }
        public int status { set; get; }
    }
}
