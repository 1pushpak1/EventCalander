using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models
{

    public class EventType
    {
        [Key]
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
    }
}