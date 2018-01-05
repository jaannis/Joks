namespace CarDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meginajums1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false),
                        Blogtext = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blogs");
        }
    }
}
