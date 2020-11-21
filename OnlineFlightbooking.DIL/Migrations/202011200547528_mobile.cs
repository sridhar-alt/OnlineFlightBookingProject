namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mobile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "MobileNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "MobileNumber");
        }
    }
}
