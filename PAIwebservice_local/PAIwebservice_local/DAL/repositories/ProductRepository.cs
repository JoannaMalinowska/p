using PAIwebservice_local.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PAIwebservice_local
{
    public class ProductRepository
    {
        public static List<Product> GetProducts()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Products.Include(b => b.category).ToList();
            }
        }

    }
}