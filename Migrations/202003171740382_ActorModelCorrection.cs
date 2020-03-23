namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActorModelCorrection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Actors", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
