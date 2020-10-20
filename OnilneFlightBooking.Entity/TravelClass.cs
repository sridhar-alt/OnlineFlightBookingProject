using System.ComponentModel.DataAnnotations;


namespace OnilneFlightBooking.Entity
{
    public class TravelClass
    {
        [Key]
        [Required]
        public int ClassId { get; set; }
        [Required]
        [StringLength(25)]
        public string ClassName { get; set; } 
    }
}
