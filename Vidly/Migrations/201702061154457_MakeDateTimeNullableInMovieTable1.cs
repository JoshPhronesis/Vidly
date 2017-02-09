namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDateTimeNullableInMovieTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.s", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.s", "Name", c => c.String(nullable: false));
        }
    }
}
