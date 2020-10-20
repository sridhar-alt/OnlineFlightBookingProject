using OnilneFlightBooking.Entity;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    //public interface IUserRepository
    //{
    //    void RegisterUser(User user);
    //    string ValidateLogin(User user);
    //}
    public class UserRepository
    {
        public static void RegisterUser(User user)          //Add the user details into the Database Table user
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    using (var transaction = userContext.Database.BeginTransaction())
                    {
                        try
                        {
                            SqlParameter mobile = new SqlParameter("@Mobile", user.Mobile);
                            SqlParameter name = new SqlParameter("@Name", user.Name);
                            SqlParameter Dob = new SqlParameter("@Dob", user.Dob);
                            SqlParameter mail = new SqlParameter("@Mail", user.Mail);
                            SqlParameter gender = new SqlParameter("@Gender", user.Gender);
                            SqlParameter userAddress = new SqlParameter("@UserAddress", user.UserAddress);
                            SqlParameter password = new SqlParameter("@Password", user.Password);
                            SqlParameter role = new SqlParameter("@Role", user.Role);
                            int result = userContext.Database.ExecuteSqlCommand("sp_InsertUser @Mobile,@Name,@Dob,@Mail,@Gender,@UserAddress,@Password,@Role", mobile, name, Dob, mail, gender, userAddress, password, role);
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();

                        }
                    }
                }
            }
            catch(Exception)
            {

            }
        }
        public static string ValidateLogin(User user)       //Validate the login user based on the mobile number and the Password 
        {
            try
            {
                using (UserContext userContext = new UserContext())
                {
                    User userDb = userContext.UserEntity.Where(model => model.Mobile == user.Mobile).Where(model => model.Password == user.Password).SingleOrDefault();
                    if (userDb != null)
                    {
                        return userDb.Role;             //if the password and the userid present return the role of the user.
                    }
                    else
                    {
                        return "NotFound";              // if it not present it return "Not present"
                    }
                }
            }
            catch(Exception)
            {
                return "Error";
            }
        }

    }
}
