namespace ShmotStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SingleOrderStatusInOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderStatusOrders", "OrderStatus_Id", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderStatusOrders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderStatusOrders", new[] { "OrderStatus_Id" });
            DropIndex("dbo.OrderStatusOrders", new[] { "Order_Id" });
            CreateIndex("dbo.Orders", "OrderStatusId");
            AddForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus", "Id");
            DropTable("dbo.OrderStatusOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderStatusOrders",
                c => new
                    {
                        OrderStatus_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderStatus_Id, t.Order_Id });
            
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            CreateIndex("dbo.OrderStatusOrders", "Order_Id");
            CreateIndex("dbo.OrderStatusOrders", "OrderStatus_Id");
            AddForeignKey("dbo.OrderStatusOrders", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderStatusOrders", "OrderStatus_Id", "dbo.OrderStatus", "Id", cascadeDelete: true);
        }
    }
}
