using OnilneFlightBooking.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFlightbooking.DIL
{
    class FlightContext: DbContext
    {
        public FlightContext() : base("DBConnection")
        {

        }
        public DbSet<FlightEntity> FlightEntity { get; set; }
    }
}
