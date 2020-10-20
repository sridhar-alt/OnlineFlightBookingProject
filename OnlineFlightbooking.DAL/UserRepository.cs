using OnilneFlightBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    public class UserRepository
    {

        public static List<UserEntity>RegisterUser()
        {
            UserContext userContext = new UserContext();
            return userContext.UserEntity.ToList();
        }
        public static void RegisterUser(UserEntity user)
        {
            UserContext userContext = new UserContext();
            userContext.UserEntity.Add(user);
            userContext.SaveChanges();
        }
        //public static Int16 ValidateLogin(UserEntity user)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            sqlConnection.Open();
        //            string sql = "SP_LOGIN";
        //            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
        //            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            SqlParameter param = new SqlParameter("@MOBILENUMBER",user.Mobile);
        //            sqlCommand.Parameters.Add(param);
        //            param = new SqlParameter("@PASSWORD",user.Password);
        //            sqlCommand.Parameters.Add(param);
        //            string Role = sqlCommand.ExecuteScalar().ToString();
        //            if (Role == "Admin")
        //            {
        //                return 1;
        //            }
        //            else if (Role == "user")
        //            {
        //                return 2;
        //            }
        //            else
        //            {
        //                return 0;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return 0;
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //}

        //public static DataTable ViewFlightDetails()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        sqlConnection.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from flightdb", sqlConnection);
        //        DataTable dataTable = new DataTable();
        //        sqlDataAdapter.Fill(dataTable);
        //        return dataTable;
        //    }
        //}
    }
}
