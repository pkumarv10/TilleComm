﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilleCommModels
{
    public class Product
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        public bool IsAvailable { get; set; }
    }
}
