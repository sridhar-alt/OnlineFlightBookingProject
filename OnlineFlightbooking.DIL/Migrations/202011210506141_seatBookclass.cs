namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seatBookclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightTravelClasses", "SeatBooked", c => c.Int(nullable: false));
            DropColumn("dbo.Flights", "SeatBooked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "SeatBooked", c => c.Int(nullable: false));
            DropColumn("dbo.FlightTravelClasses", "SeatBooked");
        }
    }
}
