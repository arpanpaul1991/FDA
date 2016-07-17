﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDA.Logic.Models
{
    public class Category
    {
        public int Id { set; get; }
        public string CategoryType { set; get; }
        public List<MenuItem_Category> menuList { get; set; }
    }
}