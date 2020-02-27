namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateActorsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Actors (Name, BirthDate) VALUES ('Will Smith', 25/09/1968)");
            Sql("INSERT INTO Actors (Name, BirthDate) VALUES ('Eddie Murphy', 3/04/1961)");
            Sql("INSERT INTO Actors (Name, BirthDate) VALUES ('Nicolas Cage', 7/01/1964)");
            Sql("INSERT INTO Actors (Name, BirthDate) VALUES ('Ray Liotta', 18/12/1954)");

        }

        public override void Down()
        {
        }
    }
}
