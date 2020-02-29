namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieCustomerManyToManyRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerMovies",
                c => new
                    {
                        Customer_ID = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_ID, t.Movie_Id })
                .ForeignKey("dbo.Customers", t => t.Customer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Customer_ID)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.CustomerMovies", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.CustomerMovies", new[] { "Movie_Id" });
            DropIndex("dbo.CustomerMovies", new[] { "Customer_ID" });
            DropTable("dbo.CustomerMovies");
        }
    }
}
