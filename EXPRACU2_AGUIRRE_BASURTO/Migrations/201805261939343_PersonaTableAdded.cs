namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonaTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 255),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 255),
                        ApellidoMaterno = c.String(nullable: false, maxLength: 255),
                        FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                        DNI = c.String(nullable: false, maxLength: 8),
                        Direccion = c.String(maxLength: 255),
                        Telefono = c.String(maxLength: 255),
                        EstadoCivil = c.String(maxLength: 255),
                        CantHijos = c.Byte(nullable: false),
                        Sexo = c.String(maxLength: 255),
                        Estado = c.String(maxLength: 255),
                        HorasExtraAcumuladas = c.Byte(nullable: false),
                        Turno_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Turnos", t => t.Turno_Id)
                .Index(t => t.Turno_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personal", "Turno_Id", "dbo.Turnos");
            DropIndex("dbo.Personal", new[] { "Turno_Id" });
            DropTable("dbo.Personal");
        }
    }
}
