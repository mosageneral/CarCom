namespace CarCom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        price = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                        Distance = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Cars", new[] { "CategoryId" });
            DropTable("dbo.Cars");
        }
    }
}
