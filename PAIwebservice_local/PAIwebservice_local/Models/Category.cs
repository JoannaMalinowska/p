using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAIwebservice_local.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string nazwa_kategorii { get; set; }
        public DateTime data { get; set; }

        public Category()
        {
            data = DateTime.Now;
        }
    }
}