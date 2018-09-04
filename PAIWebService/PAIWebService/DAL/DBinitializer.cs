using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAIWebService.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PAIWebService.DAL
{
    public class DBinitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var nowyAdmin = new IdentityRole
            {
                Name = "admin"
            };
            context.Roles.Add(nowyAdmin);
            var Admin = new ApplicationUser
            {
                Email = "admin@mail.com",
                UserName = "Admin",
                PasswordHash = "AJh93SrE12h5t+Sq0ZaUInzq5qnGglz1vTnPR1bROLzhebwpH7Zc4LdCThnmnTIGtA==",
                SecurityStamp = "ce6451c1-8a30-4a11-a248-6c2422411efa"
            };
            context.Users.Add(Admin);

            var AdminRole = new IdentityUserRole {
                UserId=nowyAdmin.Id,
                RoleId=Admin.Id
            };
            Admin.Roles.Add(AdminRole);
            context.SaveChanges();

            var category = new Category
            {
                nazwa_kategorii = "budowlane"
            };
            context.Categories.Add(category);

            var listproducts = new List<Product>
            {
              new Product{ nazwa = "cement", opis = "to jest cement", zdjecie = "tu link", cena = 3.5, category = category },
              new Product{ nazwa = "pustak", opis = "to jest pustak", zdjecie = "tutaj link", cena = 4.9, category = category },
              new Product{ nazwa = "zaprawa", opis = "to jest zaprawa", zdjecie = "tu link", cena = 12.5, category = category }

            };
            listproducts.ForEach(s => context.Products.Add(s));

        }
    }
}