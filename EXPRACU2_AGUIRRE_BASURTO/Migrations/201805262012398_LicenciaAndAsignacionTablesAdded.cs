namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LicenciaAndAsignacionTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(maxLength: 255),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        FechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        FechaFin = c.DateTime(nullable: false, storeType: "date"),
                        Estado = c.String(maxLength: 255),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personal", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.Prestamos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Decimal(nullable: false, storeType: "money"),
                        Cuotas = c.Byte(nullable: false),
                        Interes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, storeType: "money"),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        Estado = c.String(maxLength: 255),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personal", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prestamos", "Persona_Id", "dbo.Personal");
            DropForeignKey("dbo.Licencias", "Persona_Id", "dbo.Personal");
            DropIndex("dbo.Prestamos", new[] { "Persona_Id" });
            DropIndex("dbo.Licencias", new[] { "Persona_Id" });
            DropTable("dbo.Prestamos");
            DropTable("dbo.Licencias");
        }
    }
}
