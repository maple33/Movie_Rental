namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CustomerMovies (Customer_ID,Movie_Id) VALUES(1,5)");
            Sql("INSERT INTO CustomerMovies (Customer_ID,Movie_Id) VALUES(1,6)");
            Sql("INSERT INTO CustomerMovies (Customer_ID,Movie_Id) VALUES(2,2)");
            Sql("INSERT INTO CustomerMovies (Customer_ID,Movie_Id) VALUES(2,3)");
            Sql("INSERT INTO CustomerMovies (Customer_ID,Movie_Id) VALUES(2,4)");
        }
        
        public override void Down()
        {
        }
    }
}
