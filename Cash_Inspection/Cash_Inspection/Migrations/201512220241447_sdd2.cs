namespace Cash_Inspection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdd2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Subcategories", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subcategories", "Text", c => c.String());
        }
    }
}
