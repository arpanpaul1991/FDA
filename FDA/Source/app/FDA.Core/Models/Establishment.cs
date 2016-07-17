using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FDA.Core.Models
{
    public class Establishment
    {
        [Key]
        public int Id { set; get; }
        public string EstablishmentName { set; get; }
        public string OwnerName { set; get; }
        public string ContactName { set; get; }
        public string CompleteAddress { set; get; }
        public string Password { set; get; }
        public string Pincode { set; get; }
        public string Street { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public int Status { set; get; }
        public int Permission { set; get; }
    }
}