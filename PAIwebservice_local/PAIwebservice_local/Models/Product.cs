﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAIwebservice_local.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public string opis { get; set; }
        public string zdjecie { get; set; }
        public double cena { get; set; }
        public DateTime data { get; set; }

        public virtual Category category { get; set; }
        public Product()
        {
            data = DateTime.Now;
        }
    }
}