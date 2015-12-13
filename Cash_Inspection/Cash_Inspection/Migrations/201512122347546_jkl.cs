namespace Cash_Inspection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jkl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subcategories", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subcategories", "UserId");
        }
    }
}
