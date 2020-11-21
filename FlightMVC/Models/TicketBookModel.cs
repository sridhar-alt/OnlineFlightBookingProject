using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFlightBooking.Models
{
    public class TicketBookModel
    { 
        public int TicketId { get; set; }
        [Required(ErrorMessage = "Flight id required")]
        public int FlightId { get; set; }
        [Required(ErrorMessage = "class id required")]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "FlightTravelClassId Required")]
        public int FlightTravelClassId { get; set; }
        [Required(ErrorMessage="Mobile Required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Passenger Count Required")]
        public int TotalPassenger { get; set; }
        public int TotalCost { get; set; }
        public int TicketStatus { get; set; }
        [Required(ErrorMessage = "Account Number Required")]
        public int AccountNumber { get; set; }
        
    }
}