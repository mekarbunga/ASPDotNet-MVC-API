namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrasi21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_M_Supplier", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_M_Supplier", "Name", c => c.String());
        }
    }
}
