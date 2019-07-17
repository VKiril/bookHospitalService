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
    public class APIAvailabilityController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIAvailability
        public IQueryable<AvailabilityModel> GetAvailabilityModels()
        {
            return db.AvailabilityModels;
        }

        [HttpGet]
        public IList<AvailabilityFormat> CheckAvailability(int procedure, int doctor, string createdAt)
        {
            DateTime parsedDateTime = DateTime.Parse(createdAt);
            var availabilities = db.AvailabilityModels
                .Where(x => x.Doctor.Id == doctor 
                         && x.Procedure.Id == procedure 
                         && x.Date == parsedDateTime
                    )   
                .ToList();

            var data = (new AvailabitlityIntervalConstants()).AvailabilityList;

            if (availabilities.Count > 0)
            {
                foreach (AvailabilityFormat availabilityFormat in data)
                {
                    if (availabilities.Any(a => a.Interval == availabilityFormat.Id))
                    {
                        availabilityFormat.IsAvailable = false;
                    }
                }
            }

            return data;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AvailabilityModelExists(int id)
        {
            return db.AvailabilityModels.Count(e => e.Id == id) > 0;
        }
    }
}