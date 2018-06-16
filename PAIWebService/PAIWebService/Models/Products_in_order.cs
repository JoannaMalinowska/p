using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAIWebService.Models
{
    public class Products_in_order
    {
        public int ID { get; set; }
        public virtual Order zamowienie { get; set; }
        public virtual Product produkt { get; set; }
    }
}