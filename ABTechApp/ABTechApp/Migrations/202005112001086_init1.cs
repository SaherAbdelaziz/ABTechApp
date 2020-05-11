namespace ABTechApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Item = c.String(),
                        Location = c.String(),
                        WhoAssignedThisId = c.String(maxLength: 128),
                        AssignedToWhoId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedToWhoId)
                .ForeignKey("dbo.AspNetUsers", t => t.WhoAssignedThisId)
                .Index(t => t.WhoAssignedThisId)
                .Index(t => t.AssignedToWhoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "WhoAssignedThisId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "AssignedToWhoId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "AssignedToWhoId" });
            DropIndex("dbo.Orders", new[] { "WhoAssignedThisId" });
            DropTable("dbo.Orders");
        }
    }
}
