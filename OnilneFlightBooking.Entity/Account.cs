using System;
using System.ComponentModel.DataAnnotations;

namespace OnilneFlightBooking.Entity
{
    public class Account
    {
        [Key]
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public DateTime ValidDate { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
