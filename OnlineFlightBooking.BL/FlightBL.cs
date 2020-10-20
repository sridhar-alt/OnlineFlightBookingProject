using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using System.Collections.Generic;
namespace OnlineFlightBooking.BL
{
    //public interface IFlightBL
    //{
    //    List<Flight> FlightList();
    //    IEnumerable<Flight> DisplayFlight();
    //    void AddFlight(Flight flight);
    //    IEnumerable<FlightTravelClass> DisplayClass(int flightId);
    //    void CreateClass(FlightTravelClass create);
    //    void EditClass(FlightTravelClass flightTravelClass);
    //    void DeleteFlightTravelClass(FlightTravelClass deleteClass);
    //    IEnumerable<TravelClass> GetTravelClass();
    //    Flight GetFlightDetails(int flightId);
    //    FlightTravelClass GetDetailsClass(int id);
    //    void UpdateFlight(Flight flight);
    //    void DeleteFlight(Flight flight);

    //}
    public class FlightBL
    {
        public static IEnumerable<Flight> DisplayFlight()   
        {
            IEnumerable<Flight> flightDetails = FlightRepository.DisplayFlight();
            return flightDetails;                                                     //Returns the flight list from the Flight Repository
        }
        public static void AddFlight(Flight flight)
        {
            FlightRepository.AddFlight(flight);                                     //Pass the flight details to the Flight Repository
        }
        public static Flight GetFlightDetails(int flightId)
        {
            Flight flight = FlightRepository.GetFlightDetails(flightId);
            return flight;                                                    //Returns the flight details from the Flight Repository
        }
        public static FlightTravelClass GetDetailsClass(int id)
        {
            return FlightRepository.GetDetailsClass(id);                     //Returns the Flight class from the Flight Repository
        }
        public static void UpdateFlight(Flight flight)
        {
            FlightRepository.UpdateFlight(flight);                           //Pass the flight details to the Flight Repository
        }

        public static IEnumerable<FlightTravelClass> DisplayClass(int flightId)
        {
            return FlightRepository.DisplayClass(flightId);                  //Returns the Flight travel class list from the Flight Repository
        }
        public static IEnumerable<FlightTravelClass> GetFlightTravelClass()
        {
            return FlightRepository.GetFlightTravelClasses();
        }

        public static void DeleteFlight(Flight flight)
        {
            FlightRepository.DeleteFlight(flight);                       //Pass the flight details to the Flight Repository
        }

        public static IEnumerable<TravelClass> GetTravelClass()
        {
            return FlightRepository.GetTravelClass();                    //Returns the travel class list from the Flight Repository
        }

        public static void CreateClass(FlightTravelClass create)
        {
            FlightRepository.CreateClass(create);                                //Pass the flighttravelclass details to the Flight Repository
        }

        public static void EditClass(FlightTravelClass flightTravelClass)
        {
            FlightRepository.EditClass(flightTravelClass);                   //Pass the flight travel class details to the Flight Repository
        }

        public static void DeleteFlightTravelClass(FlightTravelClass flightTravelClass)
        {
            FlightRepository.DeleteFlightTravelClass(flightTravelClass);                //Pass the flight travel class details to the Flight Repository
        }

        public static List<Flight> FlightList()
        {
            throw new System.NotImplementedException();
        }
    }
}
