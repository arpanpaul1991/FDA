using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class AddMenuItemRequest
    {
        public int EID { set; get; }

        public string FoodName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        public int Status { get; set; }

       // public string Token { get; set; }
    }
}
