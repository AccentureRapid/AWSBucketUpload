namespace AWSBucket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class __firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buckets",
                c => new
                    {
                        BucketId = c.Int(nullable: false, identity: true),
                        BucketName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BucketId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        FullUrl = c.String(nullable: false),
                        FileSize = c.String(nullable: false),
                        docType = c.String(nullable: false),
                        BucketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Buckets", t => t.BucketId, cascadeDelete: true)
                .Index(t => t.BucketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "BucketId", "dbo.Buckets");
            DropIndex("dbo.Documents", new[] { "BucketId" });
            DropTable("dbo.Documents");
            DropTable("dbo.Buckets");
        }
    }
}
