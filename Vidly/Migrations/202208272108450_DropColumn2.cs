namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumn2 : DbMigration
    {
        public override void Up()
        {
           
            DropForeignKey("dbo.Customers", "membershipType_id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "membershipType_id" });
            DropColumn("dbo.Customers", "membershipType_id");

            DropColumn("dbo.Customers", "MembershiptypeId");
            
        }
        
        public override void Down()
        {
        }
    }
}
