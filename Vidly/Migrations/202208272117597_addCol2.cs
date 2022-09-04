namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCol2 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Customers", "MembershiptypeId", "dbo.MembershipTypes", "id");
        }
        
        public override void Down()
        {
        }
    }
}
