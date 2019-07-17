using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using BookHospitalService.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookHospitalService.Controllers
{
    public class PatientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patient
        public ActionResult Index()
        {
            var User = System.Web.HttpContext.Current.User;
            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var hasRoleDoctor = User.IsInRole(UserRolesConstantMoldel.RoleDoctor);
            var hasRolePatient = User.IsInRole(UserRolesConstantMoldel.RolePatient);
            if (!(hasRoleDoctor || hasRolePatient))
            {
                return RedirectToAction("Index", "CompleteProfile");
            }

            return View(db.PatientModels.ToList());
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientModel patientModel = db.PatientModels.Find(id);
            if (patientModel == null)
            {
                return HttpNotFound();
            }
            return View(patientModel);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            ViewBag.Procedures = db.ProcedureModels.ToList();
            ViewBag.Doctors = db.DoctorModels.ToList();
            ViewBag.Intervals = (new AvailabitlityIntervalConstants()).AvailabilityList;

            PatientViewModel patient = new PatientViewModel();


            return View(patient);
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Doctor,Procedure,Date,Interval,FirstLastName,Email,Phone,Notices")]
            PatientViewModel patientModel)
        {
            if (ModelState.IsValid)
            {
                var doctor = db.DoctorModels.Find(patientModel.Doctor);
                var procedure = db.ProcedureModels.Find(patientModel.Procedure);

                var availability = new AvailabilityModel()
                {
                    Doctor = doctor,
                    Date = patientModel.Date,
                    Interval = patientModel.Interval,
                    Procedure = procedure
                };

                var booking = new BookingModel()
                {
                    CreatedAt = patientModel.Date,
                    Availability = availability
                };

                var patient = new PatientModel()
                {
                    Email = patientModel.Email,
                    FirstLastName = patientModel.FirstLastName,
                    Phone = patientModel.Phone,
                    Notices = patientModel.Notices,
                    Booking = booking
                };

                db.PatientModels.Add(patient);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(patientModel);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientModel patientModel = db.PatientModels.Find(id);
            if (patientModel == null)
            {
                return HttpNotFound();
            }
            return View(patientModel);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstLastName,Email,Phone,Notices")] PatientModel patientModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientModel);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientModel patientModel = db.PatientModels.Find(id);
            if (patientModel == null)
            {
                return HttpNotFound();
            }
            return View(patientModel);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientModel patientModel = db.PatientModels.Find(id);
            db.PatientModels.Remove(patientModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
