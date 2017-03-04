namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetAvailabilityToNumberInStock : DbMigration
    {
        public override void Up()
        {
            Sql("update movies set Availability = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
