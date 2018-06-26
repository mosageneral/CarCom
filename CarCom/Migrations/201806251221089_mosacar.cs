namespace CarCom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mosacar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyTheCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyingDate = c.DateTime(nullable: false),
                        Message = c.String(),
                        UserId = c.String(maxLength: 128),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyTheCars", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BuyTheCars", "CarId", "dbo.Cars");
            DropIndex("dbo.BuyTheCars", new[] { "CarId" });
            DropIndex("dbo.BuyTheCars", new[] { "UserId" });
            DropTable("dbo.BuyTheCars");
        }
    }
}
