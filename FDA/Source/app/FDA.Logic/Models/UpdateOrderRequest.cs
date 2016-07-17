using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class UpdateOrderRequest
    {
        public int OrderId { get; set; }
        //public int EstablishmentId { get; set; }
        public int status { set; get; }
        public string Comment { get; set; }
    }
}
