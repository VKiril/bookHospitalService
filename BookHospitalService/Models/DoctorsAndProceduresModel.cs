using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class DoctorsAndProceduresModel
    {
        public int Id { get; set; }

        [Required]
        public virtual DoctorModel Doctor { get; set; }

        [Required]
        public virtual ProcedureModel Procedure { get; set; }
    }
}