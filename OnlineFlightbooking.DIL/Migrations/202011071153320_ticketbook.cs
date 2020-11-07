namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticketbook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketBooks",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 128),
                        TotalPassenger = c.Int(nullable: false),
                        TotalCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.TravelClasses", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Mobile, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.ClassId)
                .Index(t => t.Mobile);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketBooks", "Mobile", "dbo.Users");
            DropForeignKey("dbo.TicketBooks", "ClassId", "dbo.TravelClasses");
            DropForeignKey("dbo.TicketBooks", "FlightId", "dbo.Flights");
            DropIndex("dbo.TicketBooks", new[] { "Mobile" });
            DropIndex("dbo.TicketBooks", new[] { "ClassId" });
            DropIndex("dbo.TicketBooks", new[] { "FlightId" });
            DropTable("dbo.TicketBooks");
        }
    }
}
