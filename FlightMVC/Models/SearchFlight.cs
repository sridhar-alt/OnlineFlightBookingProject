using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFlightBooking.Models
{
    public class SearchFlight
    {
        [Required(ErrorMessage = " From Location required")]
        [StringLength(25, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [RegularExpression(@"(^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$)", ErrorMessage = "Invalid FlightName")]
        public string FromLocation { get; set; }
        [Required(ErrorMessage = "To Location required")]
        [StringLength(25, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [RegularExpression(@"(^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$)", ErrorMessage = "Invalid ToLocation")]
        public string ToLocation { get; set; }
        [Required(ErrorMessage = "Date required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        public DateTime Date { get; set; }
    }
}