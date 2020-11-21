using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFlightBooking.Models
{
    public class Booking
    {
        public int TicketId { get; set; }
        [Required(ErrorMessage = "Account Number Required")]
        public int TotalPassenger { get; set; }
        public int TotalCost { get; set; }
        public int AccountNumber { get; set; }


    }
}