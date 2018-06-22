using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAIWebService.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string status_zmowienia { get; set; }
        public DateTime datazamowienia { get; set; }
        public double kwota { get; set; }
        public bool zaplacone { get; set; }
        public DateTime data { get; set; }

        public virtual Client klient { get; set; }
        public virtual Product product { get; set; }

        public Order()
        {
            data = DateTime.Now;
        }
    }
}