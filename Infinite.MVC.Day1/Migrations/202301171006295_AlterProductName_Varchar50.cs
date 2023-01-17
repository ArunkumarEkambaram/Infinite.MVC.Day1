namespace Infinite.MVC.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProductName_Varchar50 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
        }
    }
}
