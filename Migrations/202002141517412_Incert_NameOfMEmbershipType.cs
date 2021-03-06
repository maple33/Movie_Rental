namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incert_NameOfMEmbershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET NameOfMembershipType = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET NameOfMembershipType = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET NameOfMembershipType = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET NameOfMembershipType = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
