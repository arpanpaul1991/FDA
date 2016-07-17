using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Core.Models
{
    public class OrderHistory
    {
        [Key]
        public int Id { set; get; }
        public string CouponId { set; get; }
        public int OrderId { set; get; }
        public int? CustomerId { set; get; }
        public string Address { set; get; }
        public int Status { set; get; }
        public DateTime CreatedDate { get; set; }
        public int EstablishmentId { set; get; }
        public string Comment { set; get; }
        public double Rating { set; get; }
        public string PhoneNumber { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
