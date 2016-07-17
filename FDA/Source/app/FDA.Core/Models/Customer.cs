using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FDA.Core.Models
{
    public class Customer
    {
        [Key]
        public int Id { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
    }
}