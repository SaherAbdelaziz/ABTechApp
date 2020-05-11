namespace ABTechApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyAnotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "AssignedToWhoId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "WhoAssignedThisId" });
            DropIndex("dbo.Orders", new[] { "AssignedToWhoId" });
            AlterColumn("dbo.Orders", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Item", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "WhoAssignedThisId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Orders", "AssignedToWhoId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Orders", "WhoAssignedThisId");
            CreateIndex("dbo.Orders", "AssignedToWhoId");
            AddForeignKey("dbo.Orders", "AssignedToWhoId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AssignedToWhoId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "AssignedToWhoId" });
            DropIndex("dbo.Orders", new[] { "WhoAssignedThisId" });
            AlterColumn("dbo.Orders", "AssignedToWhoId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "WhoAssignedThisId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "Location", c => c.String());
            AlterColumn("dbo.Orders", "Item", c => c.String());
            AlterColumn("dbo.Orders", "Phone", c => c.String());
            AlterColumn("dbo.Orders", "Name", c => c.String());
            CreateIndex("dbo.Orders", "AssignedToWhoId");
            CreateIndex("dbo.Orders", "WhoAssignedThisId");
            AddForeignKey("dbo.Orders", "AssignedToWhoId", "dbo.AspNetUsers", "Id");
        }
    }
}
