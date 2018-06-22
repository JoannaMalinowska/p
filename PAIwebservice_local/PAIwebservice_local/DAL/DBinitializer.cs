using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAIwebservice_local.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PAIwebservice_local.DAL
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
        }
    }
}