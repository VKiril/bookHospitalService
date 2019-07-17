using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public BookingModel Booking { get; set; }

        [Required]
        public string FirstLastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Notices { get; set; }

    }
}