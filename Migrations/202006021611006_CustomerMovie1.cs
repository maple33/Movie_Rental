namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerMovie1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieCustomer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.MovieId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCustomer", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieCustomer", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MovieCustomer", new[] { "MovieId" });
            DropIndex("dbo.MovieCustomer", new[] { "CustomerId" });
            DropTable("dbo.MovieCustomer");
        }
    }
}
