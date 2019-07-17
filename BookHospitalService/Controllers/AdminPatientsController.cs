using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using BookHospitalService.Models;

namespace BookHospitalService.Controllers
{
    public class AdminPatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminPatients
        public ActionResult Index()
        {
            ViewBag.Procedures = db.ProcedureModels.ToList();
            ViewBag.Doctors = db.DoctorModels.ToList();

            return View(db.PatientModels.ToList());
        }

        // POST: AdminPatients
        [HttpPost]
        public ActionResult Index(int doctor, int procedure, string date)
        {
            ViewBag.Procedures = db.ProcedureModels.ToList();
            ViewBag.Doctors = db.DoctorModels.ToList();

            #region SendFiltersBack
            if (doctor != 0)
            {
                ViewBag.SelectedDoctor = doctor;
            }
            if (procedure != 0)
            {
                ViewBag.SelectedProcedure = procedure;
            }
            if (!date.IsEmpty())
            {
                ViewBag.SelectedDate = date;
            }
            #endregion

            var query = db.PatientModels.ToList();

            #region SelectRegion
            if (doctor != 0 && procedure != 0 && !date.IsEmpty())
            {
                var DateTime = System.DateTime.Parse(date);
                query = db.PatientModels
                    .Where(p =>
                           p.Booking.Availability.Doctor.Id == doctor
                        && p.Booking.Availability.Procedure.Id == procedure
                        && p.Booking.Availability.Date == DateTime)
                    .ToList();
            }
            else if (doctor == 0 && procedure != 0 && !date.IsEmpty())
            {
                var DateTime = System.DateTime.Parse(date);
                query = db.PatientModels
                    .Where(p =>
                           p.Booking.Availability.Procedure.Id == procedure
                        && p.Booking.Availability.Date == DateTime)
                    .ToList();
            }
            else if (doctor != 0 && procedure == 0 && !date.IsEmpty())
            {
                var DateTime = System.DateTime.Parse(date);
                query = db.PatientModels
                    .Where(p =>
                        p.Booking.Availability.Doctor.Id == doctor
                        && p.Booking.Availability.Date == DateTime)
                    .ToList();
            }
            else if (doctor != 0 && procedure != 0 && date.IsEmpty())
            {
                query = db.PatientModels
                    .Where(p =>
                           p.Booking.Availability.Doctor.Id == doctor
                        && p.Booking.Availability.Procedure.Id == procedure)
                    .ToList();
            }
            else if (doctor != 0 && procedure == 0 && date.IsEmpty())
            {
                query = db.PatientModels
                    .Where(p =>
                        p.Booking.Availability.Doctor.Id == doctor)
                    .ToList();
            }
            else if (doctor == 0 && procedure != 0 && date.IsEmpty())
            {
                query = db.PatientModels
                    .Where(p =>
                        p.Booking.Availability.Procedure.Id == procedure)
                    .ToList();
            }
            else if (doctor == 0 && procedure == 0 && !date.IsEmpty())
            {
                var DateTime = System.DateTime.Parse(date);
                query = db.PatientModels
                    .Where(p =>
                        p.Booking.Availability.Date == DateTime)
                    .ToList();
            }
            #endregion

            return View(query);
        }

        // GET: AdminPatients/Details/5
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
