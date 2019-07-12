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
    public class ProcedureController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Procedure
        public ActionResult Index()
        {
            return View(db.ProcedureModels.ToList());
        }

        // GET: Procedure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedureModel procedureModel = db.ProcedureModels.Find(id);
            if (procedureModel == null)
            {
                return HttpNotFound();
            }
            return View(procedureModel);
        }

        // GET: Procedure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Details")] ProcedureModel procedureModel)
        {
            if (ModelState.IsValid)
            {
                db.ProcedureModels.Add(procedureModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(procedureModel);
        }

        // GET: Procedure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedureModel procedureModel = db.ProcedureModels.Find(id);
            if (procedureModel == null)
            {
                return HttpNotFound();
            }
            return View(procedureModel);
        }

        // POST: Procedure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Details")] ProcedureModel procedureModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedureModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedureModel);
        }

        // GET: Procedure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedureModel procedureModel = db.ProcedureModels.Find(id);
            if (procedureModel == null)
            {
                return HttpNotFound();
            }
            return View(procedureModel);
        }

        // POST: Procedure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcedureModel procedureModel = db.ProcedureModels.Find(id);
            db.ProcedureModels.Remove(procedureModel);
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
