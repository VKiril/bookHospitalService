using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class PatientViewModel
    {
        [NotMapped]
        [Required]
        public int Doctor { get; set; }

        [NotMapped]
        [Required]
        public int Procedure { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Created At")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [NotMapped]
        [Required]
        public int  Interval { get; set; }

        [NotMapped]
        [Required]
        public string FirstLastName { get; set; }

        [NotMapped]
        [Required]
        public string Email { get; set; }

        [NotMapped]
        [Required]
        public string Phone { get; set; }

        [NotMapped]
        [Required]
        public string Notices { get; set; }
    }
}