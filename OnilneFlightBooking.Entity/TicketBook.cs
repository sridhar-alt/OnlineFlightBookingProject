using System;
using System.ComponentModel.DataAnnotations;

namespace OnilneFlightBooking.Entity
{
    public class TicketBook
    {
        [Key]
        [Required]
        public int TicketId { get; set; }
        [Required]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        [Required]
        public int ClassId { get; set; }
        public TravelClass TravelClass { get; set; }
        [Required]
        public string Mobile{ get; set; }
        public User User { get; set; }
        public int TotalPassenger { get; set; }
        public int TotalCost { get; set; }

    }
}
