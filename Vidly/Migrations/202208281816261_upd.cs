namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_id" });
            DropColumn("dbo.Customers", "MembershiptypeId");
            RenameColumn(table: "dbo.Customers", name: "MembershipType_id", newName: "MembershiptypeId");
            AlterColumn("dbo.Customers", "MembershiptypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "MembershiptypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershiptypeId");
            AddForeignKey("dbo.Customers", "MembershiptypeId", "dbo.MembershipTypes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershiptypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershiptypeId" });
            AlterColumn("dbo.Customers", "MembershiptypeId", c => c.Byte());
            AlterColumn("dbo.Customers", "MembershiptypeId", c => c.Short(nullable: false));
            RenameColumn(table: "dbo.Customers", name: "MembershiptypeId", newName: "MembershipType_id");
            AddColumn("dbo.Customers", "MembershiptypeId", c => c.Short(nullable: false));
            CreateIndex("dbo.Customers", "MembershipType_id");
            AddForeignKey("dbo.Customers", "MembershipType_id", "dbo.MembershipTypes", "id");
        }
    }
}
