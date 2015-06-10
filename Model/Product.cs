﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DateTime? DateCreated { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public Product()
        {
            DateCreated = DateTime.Now;
        }
    }
}
