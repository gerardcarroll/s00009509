namespace Travel_Agency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartLocation = c.String(),
                        FinishLocation = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        TripID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trips", t => t.TripID, cascadeDelete: true)
                .Index(t => t.TripID);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        MinGuests = c.Int(nullable: false),
                        Viable = c.Boolean(nullable: false),
                        Complete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LegGuests",
                c => new
                    {
                        Leg_ID = c.Int(nullable: false),
                        Guest_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Leg_ID, t.Guest_ID })
                .ForeignKey("dbo.Legs", t => t.Leg_ID, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.Guest_ID, cascadeDelete: true)
                .Index(t => t.Leg_ID)
                .Index(t => t.Guest_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Legs", "TripID", "dbo.Trips");
            DropForeignKey("dbo.LegGuests", "Guest_ID", "dbo.Guests");
            DropForeignKey("dbo.LegGuests", "Leg_ID", "dbo.Legs");
            DropIndex("dbo.Legs", new[] { "TripID" });
            DropIndex("dbo.LegGuests", new[] { "Guest_ID" });
            DropIndex("dbo.LegGuests", new[] { "Leg_ID" });
            DropTable("dbo.LegGuests");
            DropTable("dbo.Trips");
            DropTable("dbo.Legs");
            DropTable("dbo.Guests");
        }
    }
}
