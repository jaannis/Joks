namespace CarDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        BlogCreatorID = c.String(),
                        BlogName = c.String(nullable: false),
                        BlogTitle = c.String(nullable: false),
                        BlogText = c.String(nullable: false),
                        BlogImage = c.String(),
                        BlogCreated = c.DateTime(nullable: false),
                        BlogModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.CatProfiles",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        CatName = c.String(nullable: false),
                        CatAge = c.Int(nullable: false),
                        CatImage = c.String(),
                        CatDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CatId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        CatProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.CatProfiles", t => t.FileId)
                .Index(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "FileId", "dbo.CatProfiles");
            DropIndex("dbo.Files", new[] { "FileId" });
            DropTable("dbo.Files");
            DropTable("dbo.CatProfiles");
            DropTable("dbo.Blogs");
        }
    }
}
