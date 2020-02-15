namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameOfMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "NameOfMembershipType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "NameOfMembershipType");
        }
    }
}
