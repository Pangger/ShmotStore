namespace ShmotStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersProductsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Product_ProductId" });
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Product_ProductId })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_ProductId);
            
            DropColumn("dbo.Orders", "Product_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Product_ProductId", c => c.Int());
            DropForeignKey("dbo.OrderProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "Order_Id" });
            DropTable("dbo.OrderProducts");
            CreateIndex("dbo.Orders", "Product_ProductId");
            AddForeignKey("dbo.Orders", "Product_ProductId", "dbo.Products", "ProductId");
        }
    }
}
