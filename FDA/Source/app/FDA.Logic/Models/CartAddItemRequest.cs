using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class CartAddItemRequest
    {
        public Guid GId { get; set; }
        public int MenuId { get; set; }
        public string FoodName { get; set; }

        public int TotalQuantity { get; set; }
        public int Price { get; set; }
    }
}
