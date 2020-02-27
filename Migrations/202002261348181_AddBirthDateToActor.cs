namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateToActor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "BirthDate");
        }
    }
}
