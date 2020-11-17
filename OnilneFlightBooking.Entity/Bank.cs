using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnilneFlightBooking.Entity
{
    public class Bank
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
