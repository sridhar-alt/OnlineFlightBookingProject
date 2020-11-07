using OnilneFlightBooking.Entity;
using OnlineFlightBooking.BL;
using OnlineFlightBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineFlightBooking.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Main() //View has the Layout for the Master page
        {
            
            return View();
        }
        public ActionResult Search()
        {
            //IEnumerable<Flight> flights = FlightBL.DisplayFlight();
            //List<FlightModel> flightModels = new List<FlightModel>();
            //foreach (var flight in flights)
            //{
            //    FlightModel flightModel = AutoMapper.Mapper.Map<Flight, FlightModel>(flight);       //Auto Mapper entity to model 
            //    flightModels.Add(flightModel);
            //}
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchFlight flightModel)
        { 
            Flight flight = AutoMapper.Mapper.Map<SearchFlight, Flight>(flightModel);
            IEnumerable<Flight> flights = FlightBL.SearchDisplayFlight(flight);
            TempData["Flights"] = flights;
            return RedirectToAction("UserDisplay","User");
        }
    }
}