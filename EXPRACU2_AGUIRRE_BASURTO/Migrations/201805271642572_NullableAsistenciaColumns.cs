namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableAsistenciaColumns : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Asistencias", name: "Persona_Id", newName: "PersonaId");
            RenameIndex(table: "dbo.Asistencias", name: "IX_Persona_Id", newName: "IX_PersonaId");
            AlterColumn("dbo.Asistencias", "HoraLLegada", c => c.Time(precision: 7));
            AlterColumn("dbo.Asistencias", "HoraSalida", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asistencias", "HoraSalida", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Asistencias", "HoraLLegada", c => c.Time(nullable: false, precision: 7));
            RenameIndex(table: "dbo.Asistencias", name: "IX_PersonaId", newName: "IX_Persona_Id");
            RenameColumn(table: "dbo.Asistencias", name: "PersonaId", newName: "Persona_Id");
        }
    }
}
