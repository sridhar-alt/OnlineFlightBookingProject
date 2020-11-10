namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        FlightName = c.String(nullable: false, maxLength: 25),
                        FromLocation = c.String(nullable: false, maxLength: 25),
                        ToLocation = c.String(nullable: false, maxLength: 25),
                        Date = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        TotalSeat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.FlightTravelClasses",
                c => new
                    {
                        FlightTravelClassId = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        SeatCount = c.Int(nullable: false),
                        SeatCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightTravelClassId)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.TravelClasses", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.TravelClasses",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.TicketBooks",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        FlightTravelClassId = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Mobile = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 30),
                        Dob = c.DateTime(nullable: false),
                        Mail = c.String(maxLength: 50),
                        Gender = c.Int(nullable: false),
                        UserAddress = c.String(maxLength: 50),
                        Password = c.String(maxLength: 25),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Mobile);
            
            CreateStoredProcedure(
                "dbo.sp_InsertUser",
                p => new
                    {
                        Mobile = p.String(maxLength: 128),
                        Name = p.String(maxLength: 30),
                        Dob = p.DateTime(),
                        Mail = p.String(maxLength: 50),
                        Gender = p.Int(),
                        UserAddress = p.String(maxLength: 50),
                        Password = p.String(maxLength: 25),
                        Role = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Users]([Mobile], [Name], [Dob], [Mail], [Gender], [UserAddress], [Password], [Role])
                      VALUES (@Mobile, @Name, @Dob, @Mail, @Gender, @UserAddress, @Password, @Role)"
            );
            
            CreateStoredProcedure(
                "dbo.sp_UpdateUser",
                p => new
                    {
                        Mobile = p.String(maxLength: 128),
                        Name = p.String(maxLength: 30),
                        Dob = p.DateTime(),
                        Mail = p.String(maxLength: 50),
                        Gender = p.Int(),
                        UserAddress = p.String(maxLength: 50),
                        Password = p.String(maxLength: 25),
                        Role = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Users]
                      SET [Name] = @Name, [Dob] = @Dob, [Mail] = @Mail, [Gender] = @Gender, [UserAddress] = @UserAddress, [Password] = @Password, [Role] = @Role
                      WHERE ([Mobile] = @Mobile)"
            );
            
            CreateStoredProcedure(
                "dbo.sp_DeleteUser",
                p => new
                    {
                        Mobile = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Users]
                      WHERE ([Mobile] = @Mobile)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.sp_DeleteUser");
            DropStoredProcedure("dbo.sp_UpdateUser");
            DropStoredProcedure("dbo.sp_InsertUser");
            DropForeignKey("dbo.TicketBooks", "Mobile", "dbo.Users");
            DropForeignKey("dbo.TicketBooks", "ClassId", "dbo.TravelClasses");
            DropForeignKey("dbo.TicketBooks", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.FlightTravelClasses", "ClassId", "dbo.TravelClasses");
            DropForeignKey("dbo.FlightTravelClasses", "FlightId", "dbo.Flights");
            DropIndex("dbo.TicketBooks", new[] { "Mobile" });
            DropIndex("dbo.TicketBooks", new[] { "ClassId" });
            DropIndex("dbo.TicketBooks", new[] { "FlightId" });
            DropIndex("dbo.FlightTravelClasses", new[] { "ClassId" });
            DropIndex("dbo.FlightTravelClasses", new[] { "FlightId" });
            DropTable("dbo.Users");
            DropTable("dbo.TicketBooks");
            DropTable("dbo.TravelClasses");
            DropTable("dbo.FlightTravelClasses");
            DropTable("dbo.Flights");
        }
    }
}
