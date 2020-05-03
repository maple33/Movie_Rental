namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IsSelected_to_actors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "IsSeclected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "IsSeclected");
        }
    }
}
