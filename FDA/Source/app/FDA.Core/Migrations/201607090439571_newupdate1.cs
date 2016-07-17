namespace FDA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newupdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "TotalQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetailHistory", "TotalQuantity", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "OrderId");
            DropColumn("dbo.OrderDetail", "Quantity");
            DropColumn("dbo.OrderDetailHistory", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetailHistory", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetail", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "OrderId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetailHistory", "TotalQuantity");
            DropColumn("dbo.OrderDetail", "TotalQuantity");
        }
    }
}
