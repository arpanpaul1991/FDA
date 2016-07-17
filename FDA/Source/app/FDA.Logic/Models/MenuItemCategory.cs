using FDA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class MenuItem_Category
    {
        public int MenuId { set; get; }
        public int EID { set; get; }
        public string FoodName { set; get; }
        public int Price { set; get; }
        public int Quantity { set; get; }
        public int CategoryId { set; get; }
        public int Status { set; get; }
        public int TotalQuantity { get; set; }

    }
}
