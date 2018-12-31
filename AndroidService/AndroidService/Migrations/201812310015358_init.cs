namespace AndroidService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Tekst = c.String(),
                        Op = c.String(),
                        MemeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Memes", t => t.MemeID, cascadeDelete: true)
                .Index(t => t.MemeID);
            
            CreateTable(
                "dbo.Memes",
                c => new
                    {
                        MemeID = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Beschrijving = c.String(),
                        Categorie = c.String(),
                        Afbeelding = c.String(),
                        Op = c.String(),
                    })
                .PrimaryKey(t => t.MemeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "MemeID", "dbo.Memes");
            DropIndex("dbo.Comments", new[] { "MemeID" });
            DropTable("dbo.Memes");
            DropTable("dbo.Comments");
        }
    }
}
