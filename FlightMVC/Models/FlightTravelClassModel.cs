using System.ComponentModel.DataAnnotations;


namespace OnlineFlightBooking.Models
{
    //Model for FlightTravelClass Entity
    public class FlightTravelClassModel
    {
        public int FlightTravelClassId { get; set; }
        [Required(ErrorMessage = "Flight id required")]
        public int FlightId { get; set; }
        [Required(ErrorMessage = "class id required")]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "seat count required")]
        [Range(0,900)]
        public int SeatCount { get; set; }
        [Required(ErrorMessage = "seat cost required")]
        public int SeatCost { get; set; }
        public int SeatBooked { get; set; }
    }
}