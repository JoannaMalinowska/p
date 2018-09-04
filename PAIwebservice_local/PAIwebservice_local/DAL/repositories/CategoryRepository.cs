using System;
using PAIwebservice_local.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAIwebservice_local.DAL.repositories
{
    public class CategoryRepository
    {
        public static List<Category> GetCategories()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Categories.ToList();
            }
        }
    }
}