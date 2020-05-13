namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieActor_fix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MovieActors", newName: "MovieActors1");
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        ActorId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActorId, t.MovieId })
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.ActorId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActors", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "ActorId", "dbo.Actors");
            DropIndex("dbo.MovieActors", new[] { "MovieId" });
            DropIndex("dbo.MovieActors", new[] { "ActorId" });
            DropTable("dbo.MovieActors");
            RenameTable(name: "dbo.MovieActors1", newName: "MovieActors");
        }
    }
}
