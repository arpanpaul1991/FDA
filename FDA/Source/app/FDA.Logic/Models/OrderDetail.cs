using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class OrderDetail
    {
        public int MenuId { set; get; }
        //public string FoodName { set; get; }
        public int Price { set; get; }
        public int TotalQuantity { set; get; }
        public int Order_Id { get; set; }
        

    }
}
