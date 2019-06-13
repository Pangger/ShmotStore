namespace ShmotStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnumStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            AddColumn("dbo.Orders", "OrderStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "OrderStatusId");
            DropTable("dbo.OrderStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "OrderStatusId", c => c.Int());
            DropColumn("dbo.Orders", "OrderStatus");
            CreateIndex("dbo.Orders", "OrderStatusId");
            AddForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus", "Id");
        }
    }
}
