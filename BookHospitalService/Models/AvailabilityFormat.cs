using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookHospitalService
{
    public class AvailabilityFormat
    {
        [NotMapped]
        public int Id { get; set; }

        [NotMapped]
        public string Interval { get; set; }

        [NotMapped]
        public bool IsAvailable { get; set; }
    }
}