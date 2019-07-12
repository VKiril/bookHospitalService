using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class AvailabilityModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Interval { get; set; }

        public virtual DoctorModel Doctor { get; set; }

        public virtual ProcedureModel Procedure { get; set; }
    }
}