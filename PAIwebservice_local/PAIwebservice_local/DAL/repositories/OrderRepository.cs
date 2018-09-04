using System;
using PAIwebservice_local.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PAIwebservice_local.DAL.repositories
{
    public class OrderRepository
    {
        public static List<Order> GetOrders()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
             
                return db.Orders.Include(b => b.klient).ToList();
              
            }
        }
    }
}