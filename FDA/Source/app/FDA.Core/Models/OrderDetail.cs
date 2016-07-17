using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FDA.Core.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { set; get; }
        public int MenuId { set; get; }
        //public string FoodName { set; get; }
        public int Price { set; get; }
        public int TotalQuantity { set; get; }
        public int Order_Id { set;  get; }
    }
}
