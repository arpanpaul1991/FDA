using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Core.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public Guid GId { get; set; }

        public int MenuId { get; set; }
        public string FoodName { get; set; }
        public int TotalQuantity { get; set; }
        public int Price { get; set; }
    }
}
