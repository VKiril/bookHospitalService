﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class BookingModel
    {
        public int Id { get; set; }

        [Required]
        public virtual AvailabilityModel Availability { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}