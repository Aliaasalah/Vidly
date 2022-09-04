namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmemership : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Customers", "MembershiptypeId", c => c.Short(nullable: false));
            AddColumn("dbo.Customers", "membershipType_id", c => c.Byte());
            CreateIndex("dbo.Customers", "membershipType_id");
            AddForeignKey("dbo.Customers", "membershipType_id", "dbo.MembershipTypes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "membershipType_id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "membershipType_id" });
            DropColumn("dbo.Customers", "membershipType_id");
            DropColumn("dbo.Customers", "MembershiptypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
