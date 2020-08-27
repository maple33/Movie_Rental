namespace Movie_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@" 
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e8c0133a-399d-4a25-b627-ec223a99d428', N'admin@test.com', 0, N'ALVy+unZsq0ukI8EOEa2/oRFnUJ97cDM2CUjli5IexMaVYEbqYDFCS3GGRt8WoLglw==', N'5770aff5-f298-40b9-bca4-7dd37ab37ae5', NULL, 0, 0, NULL, 1, 0, N'admin@test.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'180fc354-c6ac-4f31-8c29-b397607dde38', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e8c0133a-399d-4a25-b627-ec223a99d428', N'180fc354-c6ac-4f31-8c29-b397607dde38')

");
        }
        
        public override void Down()
        {
        }
    }
}
