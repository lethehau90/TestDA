namespace DoAn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCustomImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomImages", "BgColor", c => c.String(maxLength: 50));
            AddColumn("dbo.CustomImages", "Height", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomImages", "Height");
            DropColumn("dbo.CustomImages", "BgColor");
        }
    }
}
