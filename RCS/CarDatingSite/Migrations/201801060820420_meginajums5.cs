namespace CarDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meginajums5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "PostEmail", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "PostName", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "PostTitle", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "PostText", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "PostImage", c => c.String());
            DropColumn("dbo.Blogs", "Email");
            DropColumn("dbo.Blogs", "Name");
            DropColumn("dbo.Blogs", "Title");
            DropColumn("dbo.Blogs", "Blogtext");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Blogtext", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Blogs", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Blogs", "PostImage");
            DropColumn("dbo.Blogs", "PostText");
            DropColumn("dbo.Blogs", "PostTitle");
            DropColumn("dbo.Blogs", "PostName");
            DropColumn("dbo.Blogs", "PostEmail");
        }
    }
}
