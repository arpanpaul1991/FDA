using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class CreateOrderRequest
    {
        public string CouponId { set; get; }
        
        public int? CustomerId { set; get; }
        public string PhoneNumber { set; get; }
        public string Address { set; get; }

        public int EstablishmentId { get; set; }
        
        public DateTime DateTime { get; set; }
        public List<FDA.Logic.Models.OrderDetail> OrderDetail { set; get; }
    }
}
