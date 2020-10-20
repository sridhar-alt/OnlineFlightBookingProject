using System.ComponentModel.DataAnnotations;

namespace OnlineFlightBooking.Models
{
    //Model for User SignIn Entity
    public class SignInModel
    {
        [Required(ErrorMessage = "Phone number required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}