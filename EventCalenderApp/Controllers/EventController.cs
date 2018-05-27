using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventCalenderApp.Context;
using EventCalenderApp.Models;
using EventCalenderApp.Models.ViewModels;
using Microsoft.Ajax.Utilities;

namespace EventCalenderApp.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        public ContextManager db=new ContextManager();
        // GET: EventType
        [HttpGet]
        public ActionResult EventType()
        {
            return View();
        }
        //POST: EventType
        [HttpPost]
        public ActionResult EventType(EventTypeViewModel eventTypeVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EventType eventType=new EventType();
                    //eventType.EventTypeId = eventTypeVm.EventTypeId;
                    eventType.EventTypeName = eventTypeVm.EventTypeName;
                    db.EventTypes.Add(eventType);
                    var count=db.SaveChanges();
                    if (count>0)
                    {
                        ModelState.Clear();
                        TempData["msg"] = "Event Type information has been successfully saved.";
                        return View("EventType");
                    }
                }
                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {

                return View("Error");
            }
        }
        // GET: EventVenue
        [HttpGet]
        public ActionResult EventVenue()
        {
            
            return View();
        }
        //POST: EventVenue
        [HttpPost]
        public ActionResult EventVenue(EventVenueViewModel eventVenueVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EventVenue eventVenue = new EventVenue();
                    eventVenue.EventVenueName = eventVenueVm.EventVenueName;
                    db.EventVenues.Add(eventVenue);
                    var count = db.SaveChanges();
                    if (count > 0)
                    {
                        ModelState.Clear();
                        TempData["msg"] = "Event Venue information has been successfully saved.";
                        return View("EventVenue");
                    }
                }
                return RedirectToAction("Index","Home","Home");
            }
            catch (Exception)
            {

                return View();
            }
        }
        // GET: Event/CreateEvent
        [HttpGet]
        public ActionResult CreateEvent()
        {
            try
            {
                var eventViewModel = new EventDetailViewModel();
                var eventType = db.EventTypes.ToList();
                eventViewModel.EventTypeDropDownVm = new EventTypeDropDownViewModel()
                    {
                        EventTypes = eventType
                    };

                var eventVenue = db.EventVenues.ToList();
                eventViewModel.EventVenueDropDownVm = new EventVenueDropDownViewModel()
                {
                    EventVenues = eventVenue
                };
                return View(eventViewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // POST: Event/CreateEvent
        [HttpPost]
        public ActionResult CreateEvent(EventDetailViewModel eventVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EventDetail anEvent = new EventDetail();
                    anEvent.EventTitle = eventVm.EventTitle;
                    anEvent.EventStarTime = eventVm.EventStarTime;
                    anEvent.EventEndTime = eventVm.EventEndTime;
                    anEvent.EventMaxBookingTime = eventVm.EventMaxBookingTime;
                    anEvent.EventTypeId = eventVm.EventTypeId;
                    anEvent.EventVenueId = eventVm.EventVenueId;
                    anEvent.IsPublished = false;
                    db.EventDetails.Add(anEvent);
                    var count= db.SaveChanges();
                    if (count>0)
                    {
                        ModelState.Clear();
                        TempData["msg"] = "Event Create information has been successfully saved.";
                        return RedirectToAction("ViewEvent","Event","Event");
                    }
                }
                var eventType = db.EventTypes.ToList();
                eventVm.EventTypeDropDownVm = new EventTypeDropDownViewModel()
                {
                    EventTypeId =eventVm.EventTypeId,
                    EventTypes = eventType
                };
                var eventVenue = db.EventVenues.ToList();
                eventVm.EventVenueDropDownVm = new EventVenueDropDownViewModel()
                {
                    EventVenueId = eventVm.EventVenueId,
                    EventVenues = eventVenue
                };
                return RedirectToAction("Index","Home","Home");
            }
            catch
            {
                return View("Error");
            }
        }
        //GET: Event Details
        [HttpGet]
        public ActionResult ViewEvent()
        {
            try
            {
                var data = db.EventDetails.ToList();
                EventDetailViewModel eventDetailViewModel=new EventDetailViewModel();
                eventDetailViewModel.EventDetails = data;
                return View(eventDetailViewModel);
            }
            catch 
            {
                
                return View("Error");
            }
            
        }
        // GET: Event/Publish
        [HttpGet]
        public ActionResult Publish(int id)
        {
            try
            {
                var data = db.EventDetails.FirstOrDefault(e => e.EventId == id);
                var eventPublishViewModel = new EventPublishViewModel();
                if (data != null)
                {
                    eventPublishViewModel.EventId = data.EventId;
                    eventPublishViewModel.EventTitle = data.EventTitle;
                    eventPublishViewModel.EventStartTime = data.EventStarTime;
                    eventPublishViewModel.EventEndTime = data.EventEndTime;
                    eventPublishViewModel.EventMaxBookingTime = data.EventMaxBookingTime;
                    eventPublishViewModel.IsPublished = data.IsPublished;
                    eventPublishViewModel.IsDeleted = data.IsDeleted;
                }
                eventPublishViewModel.EventTypeName = db.EventTypes.First(x => x.EventTypeId == data.EventTypeId).EventTypeName;
                eventPublishViewModel.EventVenueName = db.EventVenues.First(x => x.EventVenueId == data.EventVenueId).EventVenueName;
                return View(eventPublishViewModel);
            }
            catch
            {
                
                return View("Error");
            }
            
        }

        // POST: Event/Publish
        [HttpPost]
        public ActionResult Publish(EventPublishViewModel eventPublishViewModel)
        {
            try
            {
                var eventDetail = db.EventDetails.Find(eventPublishViewModel.EventId);
                if (eventDetail == null)
                {
                    return new HttpNotFoundResult("No record found.");
                }
                eventDetail.IsPublished = !eventDetail.IsPublished;
                db.SaveChanges();
                return RedirectToAction("ViewEvent");
            }
            catch
            {
                return View("Error");
            }
        }
        // GET: Event/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var eventEditData = db.EventDetails.FirstOrDefault(x => x.EventId == id);
                var  eventEditViewModels=new EventEditViewModel();

                var eventType = db.EventTypes.ToList();
                eventEditViewModels.EventTypeDropDownVm = new EventTypeDropDownViewModel()
                {
                    EventTypes = eventType
                };

                var eventVenue = db.EventVenues.ToList();
                eventEditViewModels.EventVenueDropDownVm = new EventVenueDropDownViewModel()
                {
                    EventVenues = eventVenue
                };

                if (eventEditData!=null)
                {
                    eventEditViewModels.EventId = eventEditData.EventId;
                    eventEditViewModels.EventTitle = eventEditData.EventTitle;
                    eventEditViewModels.EventStarTime = eventEditData.EventStarTime;
                    eventEditViewModels.EventEndTime = eventEditData.EventEndTime;
                    eventEditViewModels.EventMaxBookingTime = eventEditData.EventMaxBookingTime;
                    eventEditViewModels.EventTypeId = eventEditData.EventTypeId;
                    eventEditViewModels.EventVenueId = eventEditData.EventVenueId;
                    eventEditViewModels.IsDeleted = eventEditData.IsDeleted;

                }
                return View(eventEditViewModels);
            }
            catch (Exception)
            {

                return View("Error");
            }
            
        }

        // POST: Event/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventEditViewModel eventEditViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EventDetail anEvent = new EventDetail();
                    anEvent.EventId = eventEditViewModel.EventId;
                    anEvent.EventTitle = eventEditViewModel.EventTitle;
                    anEvent.EventStarTime = eventEditViewModel.EventStarTime;
                    anEvent.EventEndTime = eventEditViewModel.EventEndTime;
                    anEvent.EventMaxBookingTime = eventEditViewModel.EventMaxBookingTime;
                    anEvent.EventTypeId = eventEditViewModel.EventTypeId;
                    anEvent.EventVenueId = eventEditViewModel.EventVenueId;
                    anEvent.IsPublished = false;
                    db.Entry(anEvent).State=EntityState.Modified;
                    var count = db.SaveChanges();
                    if (count > 0)
                    {
                        ModelState.Clear();
                        TempData["msg"] = "Event Edit information has been successfully updated.";
                        return RedirectToAction("ViewEvent", "Event", "Event");
                    }
                }
                return View();

            }
            catch
            {
                return View("Error");
            }
        }
        // GET: Event/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {

            try
            {
                var data = db.EventDetails.FirstOrDefault(e => e.EventId == id);
                var eventDeleteViewModel = new EventDeleteViewModel();
                if (data != null)
                {
                    eventDeleteViewModel.EventId = data.EventId;
                    eventDeleteViewModel.EventTitle = data.EventTitle;
                    eventDeleteViewModel.EventStartTime = data.EventStarTime;
                    eventDeleteViewModel.EventEndTime = data.EventEndTime;
                    eventDeleteViewModel.EventMaxBookingTime = data.EventMaxBookingTime;
                    eventDeleteViewModel.IsPublished = data.IsPublished;
                    eventDeleteViewModel.IsDeleted = data.IsDeleted;
                }
                eventDeleteViewModel.EventTypeName = db.EventTypes.First(x => x.EventTypeId == data.EventTypeId).EventTypeName;
                eventDeleteViewModel.EventVenueName = db.EventVenues.First(x => x.EventVenueId == data.EventVenueId).EventVenueName;
                return View(eventDeleteViewModel);
            }
            catch
            {

                return View("Error");
            }
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(EventDeleteViewModel eventDeleteViewModel)
        {
            try
            {
                var eventDelete = db.EventDetails.Find(eventDeleteViewModel.EventId);
                if (eventDelete == null)
                {
                    return new HttpNotFoundResult("No record found.");
                }
                eventDelete.IsDeleted = !eventDelete.IsDeleted;
                var count=db.SaveChanges();
                if (count > 0)
                {
                    TempData["msg"] = "Event information has been successfully Changed.";
                    
                }
                return RedirectToAction("ViewEvent", "Event", "Event");
            }
            catch
            {
                return View("Error");
            }
        }
        [AllowAnonymous]
        public ActionResult EventIndex()
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
                       EventType=et.EventTypeName,
                       EventVenue=ev.EventVenueName,
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
    }
}
