namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermisosTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PermisosAvanzados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motivo = c.String(maxLength: 255),
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
                "dbo.PermisosSimples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motivo = c.String(maxLength: 255),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        HoraFin = c.Time(nullable: false, precision: 7),
                        Estado = c.String(maxLength: 255),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personal", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermisosSimples", "Persona_Id", "dbo.Personal");
            DropForeignKey("dbo.PermisosAvanzados", "Persona_Id", "dbo.Personal");
            DropIndex("dbo.PermisosSimples", new[] { "Persona_Id" });
            DropIndex("dbo.PermisosAvanzados", new[] { "Persona_Id" });
            DropTable("dbo.PermisosSimples");
            DropTable("dbo.PermisosAvanzados");
        }
    }
}
