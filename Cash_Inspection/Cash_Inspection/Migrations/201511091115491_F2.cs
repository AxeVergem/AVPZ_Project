namespace Cash_Inspection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class F2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "ApplicationUser_Id");
            RenameColumn(table: "dbo.Categories", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Categories", name: "IX_ApplicationUser_Id1", newName: "IX_ApplicationUser_Id");
            AddColumn("dbo.Categories", "iUser_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "iUser_Name");
            RenameIndex(table: "dbo.Categories", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUser_Id1");
            RenameColumn(table: "dbo.Categories", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            AddColumn("dbo.Categories", "ApplicationUser_Id", c => c.String());
        }
    }
}
