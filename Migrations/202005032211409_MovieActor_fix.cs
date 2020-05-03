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
                        Actor_id = c.Int(nullable: false),
                        Movie_id = c.Int(nullable: false),
                        Actor_id1 = c.Int(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Actor_id, t.Movie_id })
                .ForeignKey("dbo.Actors", t => t.Actor_id1)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Actor_id1)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "Actor_id1", "dbo.Actors");
            DropIndex("dbo.MovieActors", new[] { "Movie_Id" });
            DropIndex("dbo.MovieActors", new[] { "Actor_id1" });
            DropTable("dbo.MovieActors");
            RenameTable(name: "dbo.MovieActors1", newName: "MovieActors");
        }
    }
}
