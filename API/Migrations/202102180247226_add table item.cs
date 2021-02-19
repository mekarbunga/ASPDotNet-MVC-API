namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableitem : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tb_M_Supplier");
            DropColumn("dbo.Tb_M_Supplier", "Id");
            AddColumn("dbo.Tb_M_Supplier", "SupplierId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Tb_M_Supplier", "Name");
            AddColumn("dbo.Tb_M_Supplier", "SupplierName", c => c.String(maxLength: 255));
            AddPrimaryKey("dbo.Tb_M_Supplier", "SupplierId");
        }
        
        public override void Down()
        {

            DropPrimaryKey("dbo.Tb_M_Supplier");
            DropColumn("dbo.Tb_M_Supplier", "SupplierName");
            AddColumn("dbo.Tb_M_Supplier", "Name", c => c.String(maxLength: 255));
            DropColumn("dbo.Tb_M_Supplier", "SupplierId");
            AddColumn("dbo.Tb_M_Supplier", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tb_M_Supplier", "Id");
        }
    }
}
