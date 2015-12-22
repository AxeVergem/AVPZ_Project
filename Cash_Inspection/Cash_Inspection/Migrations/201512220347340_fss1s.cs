namespace Cash_Inspection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fss1s : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subcategories", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Subcategories", "ApplicationUser_Id");
            AddForeignKey("dbo.Subcategories", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Categories", "iUserName");
            DropColumn("dbo.Subcategories", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subcategories", "Text", c => c.String());
            AddColumn("dbo.Categories", "iUserName", c => c.String());
            DropForeignKey("dbo.Subcategories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Subcategories", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Subcategories", "ApplicationUser_Id");
        }
    }
}
