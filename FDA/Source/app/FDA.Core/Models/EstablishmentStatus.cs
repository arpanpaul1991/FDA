﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FDA.Core.Models
{
    public class EstablishmentStatus
    {
        [Key]
        public int Id { set; get; }
        public string Status { set; get; }
    }
}