using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;

namespace OnlineFlightBooking.BL
{
    public interface IUserBL
    {
        bool ValidateUser(User user);
        void RegisterUser(User user);
        string ValidateLogin(User user);
        User GetUser(string mobile);
    }
    public class UserBL:IUserBL
    {
        public bool ValidateUser(User user)                //To check the user is already exists.
        {
            return UserRepository.ValidateUser(user);
        }
        public void RegisterUser(User user)      
        {
             UserRepository.RegisterUser(user);          // passes the  user details to the user repository
        }
        public string ValidateLogin(User user)       // check the user is registered or not
        {
            return UserRepository.ValidateLogin(user);      // passes the  user mobile number and password to the user repository
        }
        public User GetUser(string mobile)
        {
            return UserRepository.GetUser(mobile);
        }
    }
}
