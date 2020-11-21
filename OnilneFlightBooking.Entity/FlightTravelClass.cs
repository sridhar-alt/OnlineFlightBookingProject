using System.ComponentModel.DataAnnotations;

namespace OnilneFlightBooking.Entity
{
    public class FlightTravelClass
    {
        [Key]
        [Required]
        public int FlightTravelClassId { get; set; }
        [Required]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        [Required]
        public int ClassId { get; set; }
        public TravelClass TravelClass { get; set; }
        [Required]
        [Range(0,900)]
        public  int SeatCount { get; set; }
        [Required]
        public int SeatCost { get; set; }
        [Required]
        public int SeatBooked { get; set; }
}
}
