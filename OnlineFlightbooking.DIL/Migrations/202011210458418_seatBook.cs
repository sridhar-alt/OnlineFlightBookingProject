namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seatBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "SeatBooked", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "SeatBooked");
        }
    }
}
