namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert genres on");
            Sql(@"insert into genres(id,name) values(1,'Comedy')");
            Sql(@"insert into genres(id,name) values(2,'Actionn')");
            Sql(@"insert into genres(id,name) values(3,'Drama')");
            Sql(@"insert into genres(id,name) values(4,'Sci-Fi')");
            Sql("set identity_insert genres off");
        }

        public override void Down()
        {
        }
    }
}
