namespace Travel_Agency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Legs", "StartLocation", c => c.String(nullable: false));
            AlterColumn("dbo.Legs", "FinishLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Legs", "FinishLocation", c => c.String());
            AlterColumn("dbo.Legs", "StartLocation", c => c.String());
        }
    }
}
