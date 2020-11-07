namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        ArrivalTime = c.DateTime(nullable: false),
                        Duration = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.FlightTravelClasses", "ClassId", "dbo.TravelClasses");
            DropForeignKey("dbo.FlightTravelClasses", "FlightId", "dbo.Flights");
            DropIndex("dbo.FlightTravelClasses", new[] { "ClassId" });
            DropIndex("dbo.FlightTravelClasses", new[] { "FlightId" });
            DropTable("dbo.Users");
            DropTable("dbo.TravelClasses");
            DropTable("dbo.FlightTravelClasses");
            DropTable("dbo.Flights");
        }
    }
}
