using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHospitalService.Models
{
    public class AvailabitlityIntervalConstants
    {
        public AvailabilityFormat[] AvailabilityList = {
            new AvailabilityFormat() {Id = 1, Interval = "08:00-09:00", IsAvailable = true},
            new AvailabilityFormat() {Id = 2, Interval = "09:00-10:00", IsAvailable = true},
            new AvailabilityFormat() {Id = 3, Interval = "10:00-11:00", IsAvailable = true},
            new AvailabilityFormat() {Id = 4, Interval = "11:00-12:00", IsAvailable = true},
            new AvailabilityFormat() {Id = 5, Interval = "12:00-13:00", IsAvailable = true},
            new AvailabilityFormat() {Id = 6, Interval = "14:00-15:00", IsAvailable = true},
            new AvailabilityFormat() {Id = 7, Interval = "15:00-16:00", IsAvailable = true},
            new AvailabilityFormat() {Id = 8, Interval = "16:00-17:00", IsAvailable = true},
        };
    }
}