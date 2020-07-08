namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImgPathToActor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "imgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "imgPath");
        }
    }
}
