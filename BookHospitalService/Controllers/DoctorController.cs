using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookHospitalService.Models;
using BookHospitalService.Services;
using Microsoft.AspNet.Identity;

namespace BookHospitalService.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctor
        public ActionResult Index()
        {
            return View(db.DoctorModels.ToList());
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorModel doctorModel = db.DoctorModels.Find(id);
            if (doctorModel == null)
            {
                return HttpNotFound();
            }

            var doctorProcedures = db.DoctorsAndProceduresModel
                .Where(d => d.Doctor.Id == doctorModel.Id)
                .Select(d => d.Procedure)
                .ToList();

            var procedures = db.ProcedureModels.ToList();

            foreach (var doctorsAndProcedures in doctorProcedures)
            {
                procedures.RemoveAll(p => doctorsAndProcedures.Id == p.Id);
            }

            ViewBag.SelectedProcedures = doctorProcedures;
            ViewBag.AllProcedures = procedures;


            return View(doctorModel);
        }

        // GET: Doctor/AddProcedure
        public ActionResult AddProcedure(int doctorId, string procedureName)
        {
            DoctorModel doctor = db.DoctorModels.Find(doctorId);
            ProcedureModel procedure = db.ProcedureModels.SingleOrDefault(x => x.Name == procedureName);

            DoctorsAndProceduresModel model = new DoctorsAndProceduresModel()
            {
                Doctor = doctor,
                Procedure = procedure
            };

            db.DoctorsAndProceduresModel.Add(model);
            db.SaveChanges();

            return RedirectToAction("Details", new {Id = doctorId});
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            DoctorModel doctor = new DoctorModel();

            ICollection<ProcedureModel> Procedures = db.ProcedureModels.ToList();
            IList<SelectListItem> items = new List<SelectListItem>();
            foreach (var procedure in Procedures)
            {
                var tmp = new SelectListItem
                {
                    Value = procedure.Name,
                    Text = procedure.Name
                };
                items.Add(tmp);
            }

            doctor.ProcedureListItems = items;

            return View(doctor);
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category")] DoctorModel doctorModel)
        {
            (new RoleManagerService()).SetRole(Request, UserRolesConstantMoldel.RolePatient);

            //if (ModelState.IsValid)
            if (doctorModel.Category != null)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

                doctorModel.User = currentUser;
                db.DoctorModels.Add(doctorModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorModel);
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorModel doctorModel = db.DoctorModels.Find(id);
            if (doctorModel == null)
            {
                return HttpNotFound();
            }
            return View(doctorModel);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category")] DoctorModel doctorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorModel);
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorModel doctorModel = db.DoctorModels.Find(id);
            if (doctorModel == null)
            {
                return HttpNotFound();
            }
            return View(doctorModel);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorModel doctorModel = db.DoctorModels.Find(id);
            db.DoctorModels.Remove(doctorModel);
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
