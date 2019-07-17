using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookHospitalService.Models;
using BookHospitalService.Services;
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
            (new RoleManagerService()).SetRole(Request, UserRolesConstantMoldel.RolePatient);

            return RedirectToAction("Index", "Patient");
        }

        public ActionResult CompleteDoctor()
        {
            return RedirectToAction("Create", "Doctor");
        }
    }
}
