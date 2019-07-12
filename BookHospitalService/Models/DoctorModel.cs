using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public ICollection<ProcedureModel> Procedures { get; set; }

        public string Category { get; set; }
    }
}