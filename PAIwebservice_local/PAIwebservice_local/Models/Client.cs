using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAIwebservice_local.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public string adres { get; set; }
        public string miasto { get; set; }
        public DateTime data { get; set; }

        public virtual ApplicationUser user { get; set; }
        public Client()
        {
            data = DateTime.Now;
        }
    }
}