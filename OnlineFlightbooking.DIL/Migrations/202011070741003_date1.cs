namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Flights", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "Duration", c => c.DateTime(nullable: false));
            DropColumn("dbo.Flights", "Date");
        }
    }
}
