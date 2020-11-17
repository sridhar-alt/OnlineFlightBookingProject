namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        ValidDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccId = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        ValidDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccId);
            
        }
    }
}
