namespace FDA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        TotalQuantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Establishment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstablishmentName = c.String(),
                        OwnerName = c.String(),
                        ContactName = c.String(),
                        CompleteAddress = c.String(),
                        Password = c.String(),
                        Pincode = c.String(),
                        Street = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Status = c.Int(nullable: false),
                        Permission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EstablishmentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EID = c.Int(nullable: false),
                        FoodName = c.String(),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CouponId = c.String(),
                        OrderId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        Address = c.String(),
                        Status = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        EstablishmentId = c.Int(nullable: false),
                        Comment = c.String(),
                        Rating = c.Double(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetailHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CouponId = c.String(),
                        OrderId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        Address = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        EstablishmentId = c.Int(nullable: false),
                        Comment = c.String(),
                        Rating = c.Double(nullable: false),
                        PhoneNumber = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PesmissionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rating");
            DropTable("dbo.Permission");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.OrderHistory");
            DropTable("dbo.OrderDetailHistory");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Order");
            DropTable("dbo.MenuStatus");
            DropTable("dbo.MenuList");
            DropTable("dbo.EstablishmentStatus");
            DropTable("dbo.Establishment");
            DropTable("dbo.Customer");
            DropTable("dbo.Category");
            DropTable("dbo.Cart");
            DropTable("dbo.Admin");
        }
    }
}
