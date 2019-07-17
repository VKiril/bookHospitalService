 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookHospitalService.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public string Category { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ProcedureListItems { get; set; }
    }
}