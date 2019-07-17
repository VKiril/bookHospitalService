using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class AdminViewPatientsAndFilterModel
    {
        [NotMapped]
        public IList<PatientViewModel> Patients { get; set; }

        [NotMapped]
        public AdminViewFilters Form { get; set; }
    }
}