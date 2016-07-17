using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class ChangePasswordRequest
    {
        public int EID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        
    }
    
}
