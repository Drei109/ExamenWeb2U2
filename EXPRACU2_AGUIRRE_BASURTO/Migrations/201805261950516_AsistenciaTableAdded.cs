namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AsistenciaTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        HoraLLegada = c.Time(nullable: false, precision: 7),
                        HoraSalida = c.Time(nullable: false, precision: 7),
                        EsFinSemana = c.Boolean(nullable: false),
                        EsFeriado = c.Boolean(nullable: false),
                        Estado = c.String(maxLength: 255),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personal", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asistencias", "Persona_Id", "dbo.Personal");
            DropIndex("dbo.Asistencias", new[] { "Persona_Id" });
            DropTable("dbo.Asistencias");
        }
    }
}
