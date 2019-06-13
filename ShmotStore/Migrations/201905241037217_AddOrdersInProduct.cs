namespace ShmotStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersInProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.Orders", "Product_ProductId");
            AddForeignKey("dbo.Orders", "Product_ProductId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Product_ProductId" });
            DropColumn("dbo.Orders", "Product_ProductId");
        }
    }
}
