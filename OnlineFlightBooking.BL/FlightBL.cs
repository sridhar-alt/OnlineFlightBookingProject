using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using System.Collections.Generic;
namespace OnlineFlightBooking.BL
{
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
        public static IEnumerable<Flight> SearchDisplayFlight(Flight flight)
        {
            IEnumerable<Flight> flightDetails = FlightRepository.SearchDisplayFlight(flight);
            return flightDetails;                                                     //Returns the flight list from the Flight Repository
        }
        public static TravelClass GetTravelClassName(int id)
        {
            return FlightRepository.GetTravelClassName(id);
        }
        public static FlightTravelClass GetFlightTravelClass(int flightId, int classId)
        {
            return FlightRepository.GetFlightTravelClass(flightId, classId);
        }
        public static TicketBook GetBook(FlightTravelClass flightTravel, string mobile)
        {
            return FlightRepository.GetBook(flightTravel, mobile);
        }
        public static IEnumerable<TicketBook> GetBookUser(string mobile)
        {
            return FlightRepository.GetBookUser(mobile);
        }
        public static TicketBook GetBook(int id)
        {
            return FlightRepository.GetBook(id);
        }
        public static void AddTicketBook(TicketBook ticketBook)
        {
            FlightRepository.AddTicketBook(ticketBook);
        }
        public static void UpdateTicketBook(TicketBook ticketBook)
        {
            FlightRepository.UpdateTicketBook(ticketBook);
        }
        public static void DeleteTicketCount(int id)
        {
            FlightRepository.DeleteTicketCount(id);
        }
    }
}
