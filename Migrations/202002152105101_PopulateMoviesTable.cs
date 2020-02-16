namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, AddDate) VALUES ('The Rock', 'Action', 7/06/1996, 1/01/2000)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, AddDate) VALUES ('Shrek', 'Cartoon', 18/05/2001, 1/01/2000)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, AddDate) VALUES ('Shrek 2', 'Cartoon', 15/05/2004, 1/01/2000)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, AddDate) VALUES ('Shrek 3', 'Cartoon', 18/05/2007, 1/01/2000)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, AddDate) VALUES ('Goodfellas', 'Action', 7/06/1990, 1/01/2000)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, AddDate) VALUES ('Hitch', 'Comedy', 11/02/2005, 1/01/2000)");
        }
        
        public override void Down()
        {
        }
    }
}
