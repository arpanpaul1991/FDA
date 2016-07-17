using FDA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class ShowCartResponse
    {
        public List<Cart> Items { get; set; }
        public int SubTotal { get; set; }
    }
}
