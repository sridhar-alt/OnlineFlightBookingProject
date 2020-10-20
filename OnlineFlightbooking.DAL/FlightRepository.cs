using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DIL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFlightbooking.DAL
{
    public class FlightRepository
    {
        public static List<FlightEntity> ViewFlightDetails()
        {
            FlightContext flightContext = new FlightContext();
            return flightContext.FlightEntity.ToList();
        }

        //static string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //public static void InsertFlight(FlightEntity flight)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            sqlConnection.Open();
        //            SqlCommand sqlCommand = new SqlCommand("SP_FLIGHT_ADD", sqlConnection);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            SqlParameter param = new SqlParameter("@FLIGHTNAME", flight.FlightName);
        //            sqlCommand.Parameters.Add(param);
        //            param = new SqlParameter("@FLIGHTNUMBER", flight.FlightNumber);
        //            sqlCommand.Parameters.Add(param);
        //            sqlCommand.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //}
        //public static void DeleteFlight(int id)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            sqlConnection.Open();
        //            SqlCommand sqlCommand = new SqlCommand("SP_DELETE_FLIGHTDETAILS", sqlConnection);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            SqlParameter param = new SqlParameter("@FLIGHTID", id);
        //            sqlCommand.Parameters.Add(param);
        //            sqlCommand.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //}

        //public static void UpdateFlight(int id, string flightName, string flightNumber)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            sqlConnection.Open();
        //            SqlCommand sqlCommand = new SqlCommand("SP_UPDATE_FLIGHTDB", sqlConnection);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.Parameters.AddWithValue("@FLIGHTID", id);
        //            sqlCommand.Parameters.AddWithValue("@FLIGHTNAME", flightName);
        //            sqlCommand.Parameters.AddWithValue("@FLIGHTNUMBER", flightNumber);
        //            int i = sqlCommand.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //}

    }
}
