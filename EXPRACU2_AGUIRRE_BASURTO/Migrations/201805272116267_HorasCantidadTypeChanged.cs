namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HorasCantidadTypeChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HorasExtra", "HorasCantidad");
            AddColumn("dbo.HorasExtra", "HorasCantidad", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HorasExtra", "HorasCantidad");
            AddColumn("dbo.HorasExtra", "HorasCantidad", c => c.Byte(nullable: false));
        }
    }
}
