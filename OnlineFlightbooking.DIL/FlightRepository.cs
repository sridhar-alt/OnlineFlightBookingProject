using OnilneFlightBooking.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    //public interface IFlightRepository
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
    public class FlightRepository
    {
        public static List<Flight> FlightList()  //Returns the Flight list from the database
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    return userContext.FlightEntity.ToList();
                }
            }
            catch(Exception)
            {
                using (UserContext userContext = new UserContext())
                {
                    return userContext.FlightEntity.ToList();
                }
            }
            
        }
        public static IEnumerable<Flight> DisplayFlight()       //Returns the Flight list for display
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    List<Flight> flightDetails = userContext.FlightEntity.ToList();
                    return flightDetails;
                }
            }
            catch (Exception)
            {
                using (UserContext userContext = new UserContext())
                {
                    List<Flight> flightDetails = userContext.FlightEntity.ToList();
                    return flightDetails;
                }
            }

        }
        public static void AddFlight(Flight flight)         //To Add a flight details to the table from the Database
        {
            try
            {
            using (UserContext userContext = new UserContext())
            {
                userContext.FlightEntity.Add(flight);
                userContext.SaveChanges();
            }
            }
            catch (Exception)
            {
            }

        }
        public static IEnumerable<FlightTravelClass> DisplayClass(int flightId)     //Returns the FlightTravelClass Result based on the FlightId and the  flightName and the Travel Class from the DataBase
        {
            try 
            { 
                using (UserContext userContext = new UserContext())
                {
                    List<FlightTravelClass> TravelClass=userContext.FlightTravelClasses.Where(x => x.FlightId == flightId).Include(f => f.Flight).Include(f => f.TravelClass).ToList();
                    return TravelClass;
                }
            }
            catch (Exception)
            {
                using (UserContext userContext = new UserContext())
                {
                    List<FlightTravelClass> TravelClass = userContext.FlightTravelClasses.Where(x => x.FlightId == flightId).Include(f => f.Flight).Include(f => f.TravelClass).ToList();
                    return TravelClass;
                }
            }
        }
        public static IEnumerable<FlightTravelClass> GetFlightTravelClasses()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.FlightTravelClasses.ToList();
            }
        }
        public static void CreateClass(FlightTravelClass create)        //Add new FlightTravelClass to the table in the DataBase
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    userContext.FlightTravelClasses.Add(create);
                    userContext.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }
        public static void EditClass(FlightTravelClass flightTravelClass)   //Edit the FlightTravelClass in the table 
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    userContext.Entry(flightTravelClass).State = EntityState.Modified;
                    userContext.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }
        public static void DeleteFlightTravelClass(FlightTravelClass deleteClass)       //Delete the FlightTravelClass in the table
        {
            try
            {
                using(UserContext userContext=new UserContext())
                {
                    FlightTravelClass flightTravelClass = userContext.FlightTravelClasses.Where(model => model.FlightTravelClassId == deleteClass.FlightTravelClassId).SingleOrDefault();
                    userContext.FlightTravelClasses.Attach(flightTravelClass);
                    userContext.FlightTravelClasses.Remove(flightTravelClass);
                    userContext.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public static IEnumerable<TravelClass> GetTravelClass()         //return the travelclass list from the DataBase 
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    List<TravelClass> classes= userContext.TravelClasses.ToList();
                    return classes;
                }
            }
            catch (Exception)
            {
                using (UserContext userContext = new UserContext())
                {
                    List<TravelClass> classes = userContext.TravelClasses.ToList();
                    return classes;
                }
            }
        }

        public static FlightTravelClass GetDetailsClass(int id)         //return the FlightTravelClass Value Based on the FlightTravelClass Id 
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    FlightTravelClass classes = userContext.FlightTravelClasses.Where(model => model.FlightTravelClassId == id).SingleOrDefault();
                    return classes;
                }
            }
            catch (Exception)
            {
                using (UserContext userContext = new UserContext())
                {
                    FlightTravelClass classes = userContext.FlightTravelClasses.Where(model => model.FlightTravelClassId == id).SingleOrDefault();
                    return classes;
                }
            }
        }
        public static Flight GetFlightDetails(int flightId)
        {
            try
            {
                using (UserContext userContext = new UserContext())     //return the Flight Value Based on the Flight Id 
                {
                    Flight flight = userContext.FlightEntity.Where(model => model.FlightId == flightId).SingleOrDefault();
                    return flight;
                }
            }
            catch (Exception)
            {
                using (UserContext userContext = new UserContext())     //return the Flight Value Based on the Flight Id 
                {
                    Flight flight = userContext.FlightEntity.Where(model => model.FlightId == flightId).SingleOrDefault();
                    return flight;
                }
            }
        }

        public static void UpdateFlight(Flight flight)      //Modify the flight details in the table flight
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    userContext.Entry(flight).State = EntityState.Modified;
                    int change = userContext.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public static void DeleteFlight(Flight flight)          //Delete the flight details based on the flightId in the table Flight
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    Flight flightEntity = userContext.FlightEntity.Where(model => model.FlightId == flight.FlightId).SingleOrDefault();
                    userContext.FlightEntity.Attach(flightEntity);
                    userContext.FlightEntity.Remove(flightEntity);
                    userContext.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
