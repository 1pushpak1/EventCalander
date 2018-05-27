using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models.ViewModels
{
    public class EventTypeDropDownViewModel
    {
        public int EventTypeId { get; set; }
        public IEnumerable<EventType> EventTypes { get; set; }
    }
}