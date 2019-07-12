using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookHospitalService.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace BookHospitalService.Controllers
{
    public class CompleteProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompleteProfile
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult CompletePatient()
        {
            var User = System.Web.HttpContext.Current.User;
            string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityRole role = roleManager.FindByName(UserRolesConstantMoldel.RolePatient);

            //var userRole = new IdentityUserRole
            //{
            //    UserId = currentUser.Id,
            //    RoleId = role.Id
            //};

            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //currentUser.Roles.Add(userRole);

            userManager.AddToRole(currentUserId, role.Name);

            return RedirectToAction("Index", "Patient");
        }

        public ActionResult CompleteDoctor()
        {
            return RedirectToAction("Create", "Doctor");
        }
    }
}
