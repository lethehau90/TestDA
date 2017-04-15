namespace DoAn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donations", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Donations", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Donations", "CreatedBy", c => c.String());
            AddColumn("dbo.Donations", "UpdateBy", c => c.String());
            AddColumn("dbo.Donations", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Laudatories", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Laudatories", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Laudatories", "CreatedBy", c => c.String());
            AddColumn("dbo.Laudatories", "UpdateBy", c => c.String());
            AddColumn("dbo.Laudatories", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Laudatories", "CountBook", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Laudatories", "CountBook", c => c.String());
            DropColumn("dbo.Laudatories", "Status");
            DropColumn("dbo.Laudatories", "UpdateBy");
            DropColumn("dbo.Laudatories", "CreatedBy");
            DropColumn("dbo.Laudatories", "UpdateDate");
            DropColumn("dbo.Laudatories", "CreatedDate");
            DropColumn("dbo.Donations", "Status");
            DropColumn("dbo.Donations", "UpdateBy");
            DropColumn("dbo.Donations", "CreatedBy");
            DropColumn("dbo.Donations", "UpdateDate");
            DropColumn("dbo.Donations", "CreatedDate");
        }
    }
}
