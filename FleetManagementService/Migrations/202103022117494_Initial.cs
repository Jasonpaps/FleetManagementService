namespace FleetManagementService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        VesselId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerId)
                .ForeignKey("dbo.Vessels", t => t.VesselId, cascadeDelete: true)
                .Index(t => t.VesselId);
            
            CreateTable(
                "dbo.Vessels",
                c => new
                    {
                        VesselId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.VesselId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Containers", "VesselId", "dbo.Vessels");
            DropIndex("dbo.Containers", new[] { "VesselId" });
            DropTable("dbo.Vessels");
            DropTable("dbo.Containers");
        }
    }
}
