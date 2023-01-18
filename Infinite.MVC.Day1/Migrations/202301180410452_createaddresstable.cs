namespace Infinite.MVC.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createaddresstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        HouseNo = c.String(nullable: false, maxLength: 20),
                        StreetName = c.String(nullable: false, maxLength: 50),
                        FlatNo = c.String(maxLength: 10),
                        AddressLine1 = c.String(nullable: false, maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 50),
                        Pincode = c.String(nullable: false, maxLength: 6),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            DropTable("dbo.Addresses");
        }
    }
}
