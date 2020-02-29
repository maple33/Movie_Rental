namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActorsTable1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ActorMovies", newName: "MovieActors");
            DropPrimaryKey("dbo.MovieActors");
            AddPrimaryKey("dbo.MovieActors", new[] { "Movie_Id", "Actor_id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MovieActors");
            AddPrimaryKey("dbo.MovieActors", new[] { "Actor_id", "Movie_Id" });
            RenameTable(name: "dbo.MovieActors", newName: "ActorMovies");
        }
    }
}
