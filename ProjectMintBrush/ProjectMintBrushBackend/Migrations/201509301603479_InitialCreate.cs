namespace ProjectMintBrushBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserOwned = c.Int(nullable: false),
                        EntryOwned = c.Int(nullable: false),
                        TimeCreated = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnedUserID = c.Int(nullable: false),
                        EventIn = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                        PictureUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ArtistPickTime = c.DateTime(nullable: false),
                        MinPrice = c.Double(nullable: false),
                        MaxPrice = c.Double(nullable: false),
                        OptimalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
            DropTable("dbo.Entries");
            DropTable("dbo.Comments");
            DropTable("dbo.Accounts");
        }
    }
}
