namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershiptypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershiptypeId");
            
        }
        
        public override void Down()
        {
        }
    }
}
