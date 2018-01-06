namespace CarDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meginajums7 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Blogs");
            AddColumn("dbo.Blogs", "BlogId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Blogs", "BlogEmail", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "BlogName", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "BlogTitle", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "BlogText", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "BlogImage", c => c.String());
            AddPrimaryKey("dbo.Blogs", "BlogId");
            DropColumn("dbo.Blogs", "PostId");
            DropColumn("dbo.Blogs", "PostEmail");
            DropColumn("dbo.Blogs", "PostName");
            DropColumn("dbo.Blogs", "PostTitle");
            DropColumn("dbo.Blogs", "PostText");
            DropColumn("dbo.Blogs", "PostImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "PostImage", c => c.String());
            AddColumn("dbo.Blogs", "PostText", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "PostTitle", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "PostName", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "PostEmail", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "PostId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Blogs");
            DropColumn("dbo.Blogs", "BlogImage");
            DropColumn("dbo.Blogs", "BlogText");
            DropColumn("dbo.Blogs", "BlogTitle");
            DropColumn("dbo.Blogs", "BlogName");
            DropColumn("dbo.Blogs", "BlogEmail");
            DropColumn("dbo.Blogs", "BlogId");
            AddPrimaryKey("dbo.Blogs", "PostId");
        }
    }
}
