namespace ABTechApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'7fee8186-2cf6-49ef-9c77-8e5a383db811', N'Admin@users.com', 0, N'AHALjQBxEzQUrdqCtrE7vvs06nWHz7wElerlH5VaK68trY9pCF6/IJ43kIqUa7H9sQ==', N'97684084-33ce-4da3-a4c0-e1e9d958b966', NULL, 0, 0, NULL, 1, 0, N'Admin@users.com', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'98c1ca15-e7ad-4dfe-bed2-a444554a693d', N'Manger')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7fee8186-2cf6-49ef-9c77-8e5a383db811', N'98c1ca15-e7ad-4dfe-bed2-a444554a693d')

");
        }
        
        public override void Down()
        {
        }
    }
}
