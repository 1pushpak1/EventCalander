using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventCalenderApp.Context;
using EventCalenderApp.Models;
using EventCalenderApp.Models.ViewModels;

namespace EventCalenderApp.Controllers
{
   
    public class HomeController : Controller
    {

        ContextManager db = new ContextManager();
        public ActionResult Index()
        {
            try
            {
                var dataList = (from s in db.EventDetails
                                where (s.IsPublished && s.IsDeleted == false)
                                join et in db.EventTypes on s.EventTypeId equals et.EventTypeId
                                join ev in db.EventVenues on s.EventVenueId equals ev.EventVenueId
                                select new
                                {
                                    s.EventId,
                                    s.EventTitle,
                                    EventType = et.EventTypeName,
                                    EventVenue = ev.EventVenueName,
                                    s.EventStarTime,
                                    s.EventEndTime,
                                    s.EventMaxBookingTime
                                }).ToList();

                List<PublishedViewModels> publishListView = new List<PublishedViewModels>();

                
                foreach (var data in dataList)
                {
                    PublishedViewModels publishedViewModels = new PublishedViewModels();
                    publishedViewModels.EventTitle = data.EventTitle;
                    publishedViewModels.EventStartTime = data.EventStarTime;
                    publishedViewModels.EventEndTime = data.EventEndTime;
                    publishedViewModels.EventMaxBookingTime = data.EventMaxBookingTime;
                    publishedViewModels.EventTypeName = data.EventType;
                    publishedViewModels.EventVenueName = data.EventVenue;
                    publishListView.Add(publishedViewModels);
                }
                return View(publishListView);
            }
            catch
            {

                return View("Error");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}