namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameMembershipsData : DbMigration
    {
        public override void Up()
        {
            Sql("update membershipTypes set name='Pay As you go' where id=1");
            Sql("update membershipTypes set name='Monthly' where id=2");
            Sql("update membershipTypes set name='Quarter' where id=3");
            Sql("update membershipTypes set name='Yearly' where id=4");
            
        }

        public override void Down()
        {
        }
    }
}
