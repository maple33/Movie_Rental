namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectDateInDb : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET ReleaseDate = (CASE WHEN Id=1 THEN '01/06/1996' WHEN Id=2 THEN '02/02/2001' WHEN Id=3 THEN '02/02/2004' WHEN Id=4 THEN '02/02/2007' WHEN Id=5 THEN '03/06/2000' WHEN Id=6 THEN '02/02/2010' END);");
            Sql("UPDATE Movies SET AddDate = (CASE WHEN Id=1 THEN '01/06/2020' WHEN Id=2 THEN '01/06/2020' WHEN Id=3 THEN '01/06/2020' WHEN Id=4 THEN '01/06/2020' WHEN Id=5 THEN '01/06/2020' WHEN Id=6 THEN '01/06/2020' END);");
        }
        
        public override void Down()
        {
        }
    }
}
