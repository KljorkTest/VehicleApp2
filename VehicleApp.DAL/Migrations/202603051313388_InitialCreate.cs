namespace VehicleApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserVehicleEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        VehicleModelId = c.Guid(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModelEntities", t => t.VehicleModelId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.VehicleModelId);
            
            CreateTable(
                "dbo.VehicleModelEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleMakeId = c.String(),
                        Name = c.String(),
                        Abrv = c.String(),
                        Make_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleMakeEntities", t => t.Make_Id)
                .Index(t => t.Make_Id);
            
            CreateTable(
                "dbo.VehicleMakeEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Abrv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserVehicleEntities", "VehicleModelId", "dbo.VehicleModelEntities");
            DropForeignKey("dbo.VehicleModelEntities", "Make_Id", "dbo.VehicleMakeEntities");
            DropForeignKey("dbo.UserVehicleEntities", "UserId", "dbo.UserEntities");
            DropIndex("dbo.VehicleModelEntities", new[] { "Make_Id" });
            DropIndex("dbo.UserVehicleEntities", new[] { "VehicleModelId" });
            DropIndex("dbo.UserVehicleEntities", new[] { "UserId" });
            DropTable("dbo.VehicleMakeEntities");
            DropTable("dbo.VehicleModelEntities");
            DropTable("dbo.UserVehicleEntities");
            DropTable("dbo.UserEntities");
        }
    }
}
