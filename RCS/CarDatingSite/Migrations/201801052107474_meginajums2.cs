namespace CarDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meginajums2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Name");
        }
    }
}
