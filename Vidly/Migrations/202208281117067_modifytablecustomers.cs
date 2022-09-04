namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytablecustomers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershiptypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershiptypeId" });
            

        }
        
        public override void Down()
        {
        }
    }
}
