namespace Cash_Inspection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subcategories", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subcategories", "Comment");
        }
    }
}
