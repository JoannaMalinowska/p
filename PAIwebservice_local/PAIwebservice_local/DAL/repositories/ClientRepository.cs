using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAIwebservice_local.Models;
using System.Data.Entity;


namespace PAIwebservice_local.DAL.repositories
{
    public class ClientRepository
    {
        public static List<Client> GetClients()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Clients.Include(b => b.user).ToList();
            }
        }
    }
}