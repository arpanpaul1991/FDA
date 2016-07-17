using FDA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDA.Logic.Models;

namespace FDA.Logic.Models
{
   public class EstabishmentMenu
    {
       public int EID { get; set; }
       //public string CateogryType { get; set; }
       public List<Category> categoryList {get;set;}
    }
}
