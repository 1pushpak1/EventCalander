using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models
{
    public class EventVenueViewModel
    {
        public int? EventVenueId { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Venue Name")]
        public string EventVenueName { get; set; }
    }
}