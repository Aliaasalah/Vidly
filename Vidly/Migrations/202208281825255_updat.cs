namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updat : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Customers", "membershipType_id");
            AddForeignKey("dbo.Customers", "membershipType_id", "dbo.MembershipTypes", "id");
        }
        
        public override void Down()
        {
        }
    }
}
