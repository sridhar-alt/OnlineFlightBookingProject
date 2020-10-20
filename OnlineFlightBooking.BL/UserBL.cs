using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;

namespace OnlineFlightBooking.BL
{
    public class UserBL
    {
        public static void RegisterUser(User user)      
        {
            UserRepository.RegisterUser(user);          // passes the  user details to the user repository
        }
        public static string ValidateLogin(User user)       // check the user is registered or not
        {
            return UserRepository.ValidateLogin(user);      // passes the  user mobile number and password to the user repository
        }
    }
}
