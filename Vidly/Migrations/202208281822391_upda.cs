namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "membershipType_id", c => c.Byte());
            DropForeignKey("dbo.Customers", "MembershiptypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershiptypeId" });
        }
        
        public override void Down()
        {
        }
    }
}
