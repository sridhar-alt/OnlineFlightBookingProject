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

            IEnumerable<Flight> flights = FlightBL.DisplayFlight();
            List<FlightModel> flightModels = new List<FlightModel>();
            foreach (var flight in flights)
            {
                FlightModel flightModel = AutoMapper.Mapper.Map<Flight, FlightModel>(flight);       //Auto Mapper entity to model 
                flightModels.Add(flightModel);
            }
            TempData["flightsDisplay"] = flightModels;
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchFlight searchflight)
        {
            Flight flight= AutoMapper.Mapper.Map<SearchFlight, Flight>(searchflight);
            IEnumerable<Flight> flights = FlightBL.SearchDisplayFlight(flight);
            List<FlightModel> flightModels = new List<FlightModel>();
            foreach (var temp in flights)
            {
                FlightModel flightModel = AutoMapper.Mapper.Map<Flight, FlightModel>(temp);       //Auto Mapper entity to model 
                flightModels.Add(flightModel);
            }
            TempData["flightsDisplay"] = flightModels;
            return View();
        }
    }
}