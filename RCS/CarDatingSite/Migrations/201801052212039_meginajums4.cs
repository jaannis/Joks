namespace CarDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meginajums4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Blogs");
            AddColumn("dbo.Blogs", "PostId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Blogs", "Email", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Blogs", "PostId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Blogs");
            AlterColumn("dbo.Blogs", "Email", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Blogs", "PostId");
            AddPrimaryKey("dbo.Blogs", "Email");
        }
    }
}
