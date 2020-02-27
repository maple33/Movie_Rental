namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateActorsMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ActorMovies (Actor_id, Movie_id) VALUES ('2', '2')");
            Sql("INSERT INTO ActorMovies (Actor_id, Movie_id) VALUES ('2', '3')");
            Sql("INSERT INTO ActorMovies (Actor_id, Movie_id) VALUES ('2', '4')");
            Sql("INSERT INTO ActorMovies (Actor_id, Movie_id) VALUES ('3', '1')");
            Sql("INSERT INTO ActorMovies (Actor_id, Movie_id) VALUES ('4', '5')");
            Sql("INSERT INTO ActorMovies (Actor_id, Movie_id) VALUES ('1', '6')");
        }
        
        public override void Down()
        {
        }
    }
}
