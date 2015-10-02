namespace ProjectMintBrushBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationfour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "AccountType", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "PictureID", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "ProfilePictureURL", c => c.String());
            AddColumn("dbo.Accounts", "FollowerCount", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "FollowingCount", c => c.Int(nullable: false));
            AddColumn("dbo.Entries", "EventInID", c => c.Int(nullable: false));
            DropColumn("dbo.Entries", "EventIn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entries", "EventIn", c => c.Int(nullable: false));
            DropColumn("dbo.Entries", "EventInID");
            DropColumn("dbo.Accounts", "FollowingCount");
            DropColumn("dbo.Accounts", "FollowerCount");
            DropColumn("dbo.Accounts", "ProfilePictureURL");
            DropColumn("dbo.Accounts", "PictureID");
            DropColumn("dbo.Accounts", "AccountType");
        }
    }
}
