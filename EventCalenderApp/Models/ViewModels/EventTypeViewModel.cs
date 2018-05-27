using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models
{
    public class EventTypeViewModel
    {
        public int? EventTypeId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Type Name")]
        public string EventTypeName { get; set; }
    }
}