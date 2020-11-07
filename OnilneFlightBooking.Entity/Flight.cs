using System;
using System.ComponentModel.DataAnnotations;

namespace OnilneFlightBooking.Entity
{
    public class Flight
    {
        [Key]
        [Required]
        public int FlightId { get; set; }
        [Required]
        [MaxLength(25)]
        [StringLength(25)]
        public string FlightName { get; set; }
        [Required]
        [MaxLength(25)]
        public string FromLocation { get; set; }
        [Required]
        [MaxLength(25)]
        public string ToLocation { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Range(0,900)]
        public int TotalSeat { get; set; }
    }
     
}
