using Colegio.Backend.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colegio.Backend.Classes
{
    public class Utilities
    {
        private static ApplicationDbContext userContext = new ApplicationDbContext();
        private static LocalDataContext db = new LocalDataContext();

        public static void checkRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

            if(!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public static void CheckSuperUser(string role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
        }


    }
}