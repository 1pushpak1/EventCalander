using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using EventCalenderApp.Models;

namespace EventCalenderApp.Context
{

    public class ContextManager:DbContext
    {
        public ContextManager() :base("DefaultConnection")
        {
            //
        }

        
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventVenue> EventVenues { get; set; }
    }
}
