namespace Cash_Inspection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLogEntries", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserLogEntries", "ApplicationUser_Id");
            AddForeignKey("dbo.UserLogEntries", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Categories", "iUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "iUserName", c => c.String());
            DropForeignKey("dbo.UserLogEntries", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserLogEntries", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.UserLogEntries", "ApplicationUser_Id");
        }
    }
}
