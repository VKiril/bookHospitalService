﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class ProcedureModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Details { get; set; }

        public virtual DoctorModel Doctor { get; set; }
    }
}