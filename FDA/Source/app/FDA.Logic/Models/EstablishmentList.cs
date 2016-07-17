using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
   public class EstablishmentListRequest
    {
       public int EID { get; set; }
        public string Name { set; get; }

        public string Pincode { set; get; }
        public string Street { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
      
    }
}
