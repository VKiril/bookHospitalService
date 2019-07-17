using BookHospitalService.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace BookHospitalService.Services
{
    public class RoleManagerService
    {
        public void SetRole(HttpRequestBase Request, string UserRole)
        {
            var User = System.Web.HttpContext.Current.User;
            string currentUserId = User.Identity.GetUserId();

            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityRole role = roleManager.FindByName(UserRole);
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            userManager.AddToRole(currentUserId, role.Name);
        }
    }
}