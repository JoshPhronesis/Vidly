namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDateTimeNullableInMovieTable4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.s", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.s", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
