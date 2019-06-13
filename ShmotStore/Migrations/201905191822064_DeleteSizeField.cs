namespace ShmotStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSizeField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Size", c => c.String());
        }
    }
}
