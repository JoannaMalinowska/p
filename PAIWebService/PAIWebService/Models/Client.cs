using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAIWebService.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public string adres { get; set; }
        public string miasto { get; set; }

        public virtual ApplicationUser user { get; set; }
    }
}