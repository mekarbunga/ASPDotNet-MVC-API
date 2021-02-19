namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tes2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tb_M_Item");
            DropColumn("dbo.Tb_M_Item", "Id");
            AddColumn("dbo.Tb_M_Item", "ItemId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Tb_M_Item", "Name");
            DropColumn("dbo.Tb_M_Item", "Quantity");
            DropColumn("dbo.Tb_M_Item", "Price");
            AddColumn("dbo.Tb_M_Item", "ItemName", c => c.String());
            AddColumn("dbo.Tb_M_Item", "ItemQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Tb_M_Item", "ItemPrice", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tb_M_Item", "ItemId");
        }
        
        public override void Down()
        {

            DropPrimaryKey("dbo.Tb_M_Item");
            AddPrimaryKey("dbo.Tb_M_Item", "Id");
            DropColumn("dbo.Tb_M_Item", "ItemPrice");
            AddColumn("dbo.Tb_M_Item", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Tb_M_Item", "ItemQuantity");
            DropColumn("dbo.Tb_M_Item", "ItemName");
            DropColumn("dbo.Tb_M_Item", "ItemId");
            AddColumn("dbo.Tb_M_Item", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Tb_M_Item", "Name", c => c.String());
            AddColumn("dbo.Tb_M_Item", "Id", c => c.Int(nullable: false, identity: true));
        }
    }
}
