using OnilneFlightBooking.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineFlightBooking.Models
{
    //Model for User Entity SignUp
    public class SignUpModel
    {

        [Required(ErrorMessage = "Name required")]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [RegularExpression(@"(^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$)", ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Enter the numeric digits.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Date of Birth required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Gender required")]
        public gender Gender { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string UserAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm password must be same")]
        public string ConfirmPassword { get; set; }

        public string Role = "User";
    }
}