namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class posterPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "posterPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "posterPath");
        }
    }
}
