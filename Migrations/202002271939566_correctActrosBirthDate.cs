namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctActrosBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Actors SET BirthDate = (CASE WHEN Id=1 THEN '19680925' WHEN Id=2 THEN '19610403' WHEN Id=3 THEN '19640107' WHEN Id=4 THEN '19541218' END);");
        }
        
        public override void Down()
        {
        }
    }
}
