using OnilneFlightBooking.Entity;
using System.Data.Entity;

namespace OnlineFlightbooking.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DBConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)        //Store procedure for the User entity(Insert, Update, Delete)
        {
            modelBuilder.Entity<User>()
                .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertUser"))     
                .Update(sp => sp.HasName("sp_UpdateUser"))
                .Delete(sp => sp.HasName("sp_DeleteUser"))
                );
        }
        public DbSet<User> UserEntity { get; set; }     //Table for the user
        public DbSet<Flight> FlightEntity { get; set; }     //Table for the Flight
        public DbSet<FlightTravelClass> FlightTravelClasses{get;set; }     //Table for the Flight Travel Class
        public DbSet<TravelClass> TravelClasses { get; set; }     //Table for the Travel Class
        public DbSet<TicketBook> TicketBooks { get; set; }
    }
}
