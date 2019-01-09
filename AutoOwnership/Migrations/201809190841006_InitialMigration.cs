namespace AutoOwnership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(),
                        YearOfIssue = c.Short(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Models", t => t.ModelId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        BrandId = c.Int(),
                        Name = c.String(),
                        CarType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DrivingExperience = c.Short(nullable: false),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.OwnerCars",
                c => new
                    {
                        Owner_OwnerId = c.Int(nullable: false),
                        Car_CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Owner_OwnerId, t.Car_CarId })
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_CarId, cascadeDelete: true)
                .Index(t => t.Owner_OwnerId)
                .Index(t => t.Car_CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OwnerCars", "Car_CarId", "dbo.Cars");
            DropForeignKey("dbo.OwnerCars", "Owner_OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Cars", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropIndex("dbo.OwnerCars", new[] { "Car_CarId" });
            DropIndex("dbo.OwnerCars", new[] { "Owner_OwnerId" });
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropIndex("dbo.Cars", new[] { "ModelId" });
            DropTable("dbo.OwnerCars");
            DropTable("dbo.Owners");
            DropTable("dbo.Brands");
            DropTable("dbo.Models");
            DropTable("dbo.Cars");
        }
    }
}
