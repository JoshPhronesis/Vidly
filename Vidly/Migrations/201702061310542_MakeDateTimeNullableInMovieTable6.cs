namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDateTimeNullableInMovieTable6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.s", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.s", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
