using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookHospitalService.Models;

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
            return View(doctorModel);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            var procedures = db.ProcedureModels.ToList();
            ViewBag.Procedures = procedures;

            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category")] DoctorModel doctorModel)
        {
            if (ModelState.IsValid)
            {
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
