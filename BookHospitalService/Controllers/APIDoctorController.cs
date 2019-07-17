using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookHospitalService.Models;

namespace BookHospitalService.Controllers
{
    public class APIDoctorController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIPatient
        [HttpGet]
        public IList<DoctorModel> GetDoctorModelsByProcedure(int procedure)
        {
            var doctors = db.DoctorsAndProceduresModel
                .Where(x => x.Procedure.Id == procedure)
                //.Select((Doctor) => new { Doctor })
                .Select(x => x.Doctor)
                .DefaultIfEmpty();

            return doctors.ToList();
            //return db.DoctorModels.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorModelExists(int id)
        {
            return db.DoctorModels.Count(e => e.Id == id) > 0;
        }
    }
}