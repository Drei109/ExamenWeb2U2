namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HorasExtraColumnChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Personal", "HorasExtraAcumuladas");
            AddColumn("dbo.Personal", "HorasExtraAcumuladas", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personal", "HorasExtraAcumuladas");
            AddColumn("dbo.Personal", "HorasExtraAcumuladas", c => c.Byte(nullable: false));
        }
    }
}
