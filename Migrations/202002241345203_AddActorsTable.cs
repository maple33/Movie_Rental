namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActorsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ActorMovies",
                c => new
                    {
                        Actor_id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_id, t.Movie_Id })
                .ForeignKey("dbo.Actors", t => t.Actor_id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Actor_id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.ActorMovies", "Actor_id", "dbo.Actors");
            DropIndex("dbo.ActorMovies", new[] { "Movie_Id" });
            DropIndex("dbo.ActorMovies", new[] { "Actor_id" });
            DropTable("dbo.ActorMovies");
            DropTable("dbo.Actors");
        }
    }
}
