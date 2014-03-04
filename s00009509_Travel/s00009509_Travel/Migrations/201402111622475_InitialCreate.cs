namespace s00009509_Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Leg_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Legs", t => t.Leg_ID)
                .Index(t => t.Leg_ID);
            
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartLocation = c.String(),
                        FinishLocation = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        Trip_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trips", t => t.Trip_ID)
                .Index(t => t.Trip_ID);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        MinGuests = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Legs", "Trip_ID", "dbo.Trips");
            DropForeignKey("dbo.Guests", "Leg_ID", "dbo.Legs");
            DropIndex("dbo.Legs", new[] { "Trip_ID" });
            DropIndex("dbo.Guests", new[] { "Leg_ID" });
            DropTable("dbo.Trips");
            DropTable("dbo.Legs");
            DropTable("dbo.Guests");
        }
    }
}
