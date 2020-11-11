using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using System.Collections.Generic;
namespace OnlineFlightBooking.BL
{
    public interface IFlightBL
    {
        IEnumerable<Flight> DisplayFlight();
        void AddFlight(Flight flight);
        Flight GetFlightDetails(int flightId);
        FlightTravelClass GetDetailsClass(int id);
        void UpdateFlight(Flight flight);
        IEnumerable<FlightTravelClass> DisplayClass(int flightId);
        IEnumerable<FlightTravelClass> GetFlightTravelClass();
        void DeleteFlight(Flight flight);
        IEnumerable<TravelClass> GetTravelClass();
        void CreateClass(FlightTravelClass create);
        void EditClass(FlightTravelClass flightTravelClass);
        void DeleteFlightTravelClass(FlightTravelClass flightTravelClass);
        List<Flight> FlightList();
        IEnumerable<Flight> SearchDisplayFlight(Flight flight);
        TravelClass GetTravelClassName(int id);
        FlightTravelClass GetFlightTravelClass(int flightId, int classId);
        TicketBook GetBookUserId(FlightTravelClass flightTravel, string mobile);
        IEnumerable<TicketBook> GetBookUser(string mobile);
        TicketBook GetBook(int id);
        void AddTicketBook(TicketBook ticketBook);
        void UpdateTicketBook(TicketBook ticketBook);
        void DeleteTicketCount(int id);
    }
    public class FlightBL:IFlightBL
    {
        public IEnumerable<Flight> DisplayFlight()
        {
            IEnumerable<Flight> flightDetails = FlightRepository.DisplayFlight();
            return flightDetails;                                                     //Returns the flight list from the Flight Repository
        }
        public void AddFlight(Flight flight)
        {
            FlightRepository.AddFlight(flight);                                     //Pass the flight details to the Flight Repository
        }
        public Flight GetFlightDetails(int flightId)
        {
            Flight flight = FlightRepository.GetFlightDetails(flightId);
            return flight;                                                    //Returns the flight details from the Flight Repository
        }
        public FlightTravelClass GetDetailsClass(int id)
        {
            return FlightRepository.GetDetailsClass(id);                     //Returns the Flight class from the Flight Repository
        }
        public void UpdateFlight(Flight flight)
        {
            FlightRepository.UpdateFlight(flight);                           //Pass the flight details to the Flight Repository
        }

        public IEnumerable<FlightTravelClass> DisplayClass(int flightId)
        {
            return FlightRepository.DisplayClass(flightId);                  //Returns the Flight travel class list from the Flight Repository
        }
        public IEnumerable<FlightTravelClass> GetFlightTravelClass()
        {
            return FlightRepository.GetFlightTravelClasses();
        }

        public void DeleteFlight(Flight flight)
        {
            FlightRepository.DeleteFlight(flight);                       //Pass the flight details to the Flight Repository
        }

        public IEnumerable<TravelClass> GetTravelClass()
        {
            return FlightRepository.GetTravelClass();                    //Returns the travel class list from the Flight Repository
        }

        public void CreateClass(FlightTravelClass create)
        {
            FlightRepository.CreateClass(create);                                //Pass the flighttravelclass details to the Flight Repository
        }

        public void EditClass(FlightTravelClass flightTravelClass)
        {
            FlightRepository.EditClass(flightTravelClass);                   //Pass the flight travel class details to the Flight Repository
        }

        public void DeleteFlightTravelClass(FlightTravelClass flightTravelClass)
        {
            FlightRepository.DeleteFlightTravelClass(flightTravelClass);                //Pass the flight travel class details to the Flight Repository
        }

        public List<Flight> FlightList()
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<Flight> SearchDisplayFlight(Flight flight)
        {
            IEnumerable<Flight> flightDetails = FlightRepository.SearchDisplayFlight(flight);
            return flightDetails;                                                     //Returns the flight list from the Flight Repository
        }
        public TravelClass GetTravelClassName(int id)
        {
            return FlightRepository.GetTravelClassName(id);
        }
        public FlightTravelClass GetFlightTravelClass(int flightId, int classId)
        {
            return FlightRepository.GetFlightTravelClass(flightId, classId);
        }
        public TicketBook GetBookUserId(FlightTravelClass flightTravel, string mobile)
        {
            return FlightRepository.GetBookUserId(flightTravel, mobile);
        }
        public IEnumerable<TicketBook> GetBookUser(string mobile)
        {
            return FlightRepository.GetBookUser(mobile);
        }
        public TicketBook GetBook(int id)
        {
            return FlightRepository.GetBook(id);
        }
        public void AddTicketBook(TicketBook ticketBook)
        {
            FlightRepository.AddTicketBook(ticketBook);
        }
        public void UpdateTicketBook(TicketBook ticketBook)
        {
            FlightRepository.UpdateTicketBook(ticketBook);
        }
        public void DeleteTicketCount(int id)
        {
            FlightRepository.DeleteTicketCount(id);
        }
    }
}
