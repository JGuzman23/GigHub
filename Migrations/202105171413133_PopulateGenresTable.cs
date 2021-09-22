namespace GitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Id, Name) values (1,'Dembow')");
            Sql("insert into Genres (Id, Name) values (2,'Reggue')");
            Sql("insert into Genres (Id, Name) values (3,'Gospel')");
            Sql("insert into Genres (Id, Name) values (4,'Rap')"); 


        }

        public override void Down()
        {
            Sql("Delete from genres where Id IN (1,2,3,4) ");
        }
    }
}
