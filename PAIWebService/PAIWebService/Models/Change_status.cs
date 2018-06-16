using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAIWebService.Models
{
    public class Change_status
    {
        public int ID { get; set; }
        public DateTime data_zmiany { get; set; }
        public string nowy_status { get; set; }
        public string stary_status { get; set; }

        public virtual Order zamowienie { get; set; }
    }
}