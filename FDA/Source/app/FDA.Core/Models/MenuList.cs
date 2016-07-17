using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FDA.Core.Models
{
    public class MenuList
    {
        [Key]
        public int Id { set; get; }
        public int EID { set; get; }
        public string FoodName { set; get; }
        public int Price { set; get; }
        public int Quantity { set; get; }
        public int CategoryId { set; get; }
        public int Status { set; get; }
    }
}