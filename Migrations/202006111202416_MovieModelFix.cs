namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieModelFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Customers", new[] { "Movie_Id" });
            DropColumn("dbo.Customers", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Movie_Id");
            AddForeignKey("dbo.Customers", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
