namespace DoAn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCustomImageinAuditable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomImages", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.CustomImages", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.CustomImages", "CreatedBy", c => c.String());
            AddColumn("dbo.CustomImages", "UpdateBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomImages", "UpdateBy");
            DropColumn("dbo.CustomImages", "CreatedBy");
            DropColumn("dbo.CustomImages", "UpdateDate");
            DropColumn("dbo.CustomImages", "CreatedDate");
        }
    }
}
