namespace Infinite.MVC.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EmailId", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "MobileNo", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "MobileNo", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "EmailId");
        }
    }
}
