namespace DoAn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaddingAndHeightCustomHeader : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomHeaders", "PaddingTop", c => c.Int(nullable: false));
            AddColumn("dbo.CustomHeaders", "Height", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomHeaders", "Height");
            DropColumn("dbo.CustomHeaders", "PaddingTop");
        }
    }
}
