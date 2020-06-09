namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieCustomers", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieCustomers", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.MovieCustomers", new[] { "Movie_Id" });
            DropIndex("dbo.MovieCustomers", new[] { "Customer_ID" });
            AddColumn("dbo.Customers", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Movie_Id");
            AddForeignKey("dbo.Customers", "Movie_Id", "dbo.Movies", "Id");
            DropTable("dbo.MovieCustomers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieCustomers",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Customer_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Customer_ID });
            
            DropForeignKey("dbo.Customers", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Customers", new[] { "Movie_Id" });
            DropColumn("dbo.Customers", "Movie_Id");
            CreateIndex("dbo.MovieCustomers", "Customer_ID");
            CreateIndex("dbo.MovieCustomers", "Movie_Id");
            AddForeignKey("dbo.MovieCustomers", "Customer_ID", "dbo.Customers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MovieCustomers", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
