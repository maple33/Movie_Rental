namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "videoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "videoPath");
        }
    }
}
