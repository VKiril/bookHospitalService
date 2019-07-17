using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class AdminViewFilters
    {
        [NotMapped]
        public int Procedure { get; set; }

        [NotMapped]
        public int Doctor { get; set; }

        [NotMapped]
        public DateTime Date { get; set; }

        [NotMapped]
        public string Patient { get; set; }
    }
}