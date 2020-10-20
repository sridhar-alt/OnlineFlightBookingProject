using OnlineFlightBooking.Models;
using OnilneFlightBooking.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineFlightBooking.BL;

namespace OnlineFlightBooking.Controllers
{
    [Authorize(Roles="admin")]
    public class FlightController : Controller
    {
        // GET: Flight
       
        public ActionResult DisplayFlight()
        {
            IEnumerable<Flight> flights = FlightBL.DisplayFlight();
            IEnumerable<FlightTravelClass> flightTravelClasses = FlightBL.GetFlightTravelClass();
            IEnumerable<TravelClass> travelClasses = FlightBL.GetTravelClass();
            TempData["FlightTravelClass"] = flightTravelClasses;
            TempData["TravelClass"] = travelClasses;
            List<FlightModel> flightModels = new List<FlightModel>();
            foreach(var flight in flights)
            {
                FlightModel flightModel = AutoMapper.Mapper.Map<Flight, FlightModel>(flight);       //Auto Mapper entity to model 
                flightModels.Add(flightModel);
            }
            return View(flightModels);      //Calling View for the Display Flight
        }
        // GET: AddFlight
        [HttpGet]
        public ActionResult AddFlight()
        {
            return View();      //Calling View for the Add Flight
        }
        // POST: AddFlight
        [HttpPost]
        public ActionResult AddFlight(FlightModel add)
        {
            if (ModelState.IsValid)     //condition pass when all the model state validation is true
            {
                Flight flight = AutoMapper.Mapper.Map<FlightModel, Flight>(add);   //Auto Mapper model to entity
                FlightBL.AddFlight(flight);
                TempData["message"] = "Flight added successfully";
                TempData["FlightId"] = flight.FlightId;
                return RedirectToAction("CreateClass", "FlightTravelClasses");
            }
            return View();      //Calling View for the AddFlight (when the ModelState is in valid)
        }
        // GET: EditFlight
        [HttpGet]
        public ActionResult EditFlight(int Id)
        {
            Flight flight = FlightBL.GetFlightDetails(Id); 
            FlightModel flightModel = AutoMapper.Mapper.Map<Flight,FlightModel>(flight);   //Auto Mapper entity to model 
            return View(flightModel);       //Calling View for the Edit Flight
        }
        // POST: EditFlight
        [HttpPost]
        public ActionResult EditFlight(FlightModel edit)
        {
            if (ModelState.IsValid)     //condition pass when all the model state validation is true
            {
                Flight flight=AutoMapper.Mapper.Map<FlightModel, Flight>(edit);     //Auto Mapper model to entity
                FlightBL.UpdateFlight(flight);
                TempData["message"] = "Flight Updated successfully";
                TempData["FlightId"] = flight.FlightId;
                return RedirectToAction("DisplayClass", "FlightTravelClasses");
            }
            return View();      //Calling View for the EditFlight(when the ModelState is in valid)
        }
        // GET: DeleteFlight
        [HttpGet]
        public ActionResult DeleteFlight(int Id)
        {
            Flight flight = FlightBL.GetFlightDetails(Id);
            FlightModel flightModel = AutoMapper.Mapper.Map<Flight, FlightModel>(flight);   //Auto Mapper entity to model 
            return View(flightModel);           //Calling View for the Delste Flight
        }
        // POST: DeleteFlight
        [HttpPost]
        public ActionResult DeleteFlight(FlightModel delete)
        {
            Flight flight = AutoMapper.Mapper.Map<FlightModel, Flight>(delete);     //Auto Mapper model to entity
            FlightBL.DeleteFlight(flight);
            TempData["message"] = "Flight deleted successfully";
            return RedirectToAction("DisplayFlight");
        }
    }
}