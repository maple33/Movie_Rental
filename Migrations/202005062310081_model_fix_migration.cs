namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model_fix_migration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerMovies", newName: "MovieCustomers");
            DropForeignKey("dbo.MovieActors1", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieActors1", "Actor_id", "dbo.Actors");
            DropIndex("dbo.MovieActors1", new[] { "Movie_Id" });
            DropIndex("dbo.MovieActors1", new[] { "Actor_id" });
            DropPrimaryKey("dbo.MovieCustomers");
            AddPrimaryKey("dbo.MovieCustomers", new[] { "Movie_Id", "Customer_ID" });
            DropTable("dbo.MovieActors1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieActors1",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Actor_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Actor_id });
            
            DropPrimaryKey("dbo.MovieCustomers");
            AddPrimaryKey("dbo.MovieCustomers", new[] { "Customer_ID", "Movie_Id" });
            CreateIndex("dbo.MovieActors1", "Actor_id");
            CreateIndex("dbo.MovieActors1", "Movie_Id");
            AddForeignKey("dbo.MovieActors1", "Actor_id", "dbo.Actors", "id", cascadeDelete: true);
            AddForeignKey("dbo.MovieActors1", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.MovieCustomers", newName: "CustomerMovies");
        }
    }
}
