using OnilneFlightBooking.Entity;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    public class UserRepository
    {
        public static bool ValidateUser(User user)              //To check the user is already exists.
        {
            using (UserContext userContext = new UserContext())
            {
                if(userContext.UserEntity.Where(x => x.Mobile == user.Mobile).FirstOrDefault()==null)
                {
                    return true;
                }
                return false;
            }
        }
        public static void RegisterUser(User user)          //Add the user details into the Database Table user
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
