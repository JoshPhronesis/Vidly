namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'1f10923f-6793-4cb6-bb39-26ad3829416f', N'admin1@vidly.com', 0, N'AKbP+r37kHmoU2oHO0Ikzfedme16z3OhoLqIvTRsgB+7osSLLrHBq0F2q4dYFbRzLQ==', N'b3bd80bc-2de4-498d-9c77-f3777dd4c542', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')
INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'6b7dfaff-0ae3-492a-87b3-1449a48b98d5', N'guest@vidly.com', 0, N'AHsyj0BM8e1a1EkuU5Z7oKh0IMpINWYEQCDFapL5Ou2wnbQrYUghgqMWMYGOKBS9Aw==', N'02f52fb3-68e0-4664-87ed-9cec52293cfc', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7cd178cb-948f-4fd5-b733-48fc55123c58', N'CanManageMovie')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'485b83e7-868c-44a9-bf25-af9914fc3690', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1f10923f-6793-4cb6-bb39-26ad3829416f', N'485b83e7-868c-44a9-bf25-af9914fc3690')

                ");
        }

        public override void Down()
        {
        }
    }
}
