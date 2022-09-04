namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcol4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "membershipType_id", c => c.Byte());
        }
        
        public override void Down()
        {
        }
    }
}
