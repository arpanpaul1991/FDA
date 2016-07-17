using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class ShowOrderResponse
    {
        public int Id { set; get; }
        public string CouponId { set; get; }

        public string PhoneNumber { set; get; }
        public string Address { set; get; }
        public string Comment { set; get; }

        public int Status { set; get; }
        public DateTime DateTime { get; set; }
        public List<FDA.Logic.Models.ShowOrderDetailsResponse> OrderDetail { set; get; }
    }
}
