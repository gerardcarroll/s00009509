namespace Travel_Agency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LegChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Guests", "LegID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guests", "LegID", c => c.Int(nullable: false));
        }
    }
}
