namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HorasCompensadasInCompensacionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compensaciones", "HorasCompensadas", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compensaciones", "HorasCompensadas");
        }
    }
}
