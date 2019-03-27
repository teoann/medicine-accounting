﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAccountingAPI.DataLevel
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
