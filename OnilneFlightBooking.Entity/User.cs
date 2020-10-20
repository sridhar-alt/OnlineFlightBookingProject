using System;
using System.ComponentModel.DataAnnotations;

namespace OnilneFlightBooking.Entity
{
    public enum gender
    {
        male,
        female
    }
    public class User
    {
        [StringLength(30)]
        public string Name { get; set; }
        [Key]
        [Required]
        public string Mobile { get; set; }
        public DateTime Dob { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        public gender Gender { get; set; }
        [StringLength(50)]
        public string UserAddress { get; set; }
        [StringLength(25)]
        public string Password { get; set; }
        public string Role { get; set; }
        public User()
        { }
    }
    
}
