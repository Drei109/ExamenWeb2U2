namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HorasExtraTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HorasExtra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        Motivo = c.String(maxLength: 255),
                        Aumenta = c.Boolean(nullable: false),
                        HorasCantidad = c.Byte(nullable: false),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personal", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HorasExtra", "Persona_Id", "dbo.Personal");
            DropIndex("dbo.HorasExtra", new[] { "Persona_Id" });
            DropTable("dbo.HorasExtra");
        }
    }
}
