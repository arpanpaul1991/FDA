using FDA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class EditMenuItemRequest
    {
        public int EstablishmentID { get; set; }
        public int MenuId { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }
    }
}
