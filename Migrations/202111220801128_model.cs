namespace ICEP_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buses", "TotalRequest", c => c.Int(nullable: false));
            AddColumn("dbo.BusDrivers", "EmailUsername", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BusDrivers", "EmailUsername");
            DropColumn("dbo.Buses", "TotalRequest");
        }
    }
}
