namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysNameChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HorasExtra", "Persona_Id", "dbo.Personal");
            DropIndex("dbo.HorasExtra", new[] { "Persona_Id" });
            RenameColumn(table: "dbo.Asignaciones", name: "Persona_Id", newName: "PersonaId");
            RenameColumn(table: "dbo.Compensaciones", name: "Persona_Id", newName: "PersonaId");
            RenameColumn(table: "dbo.HorasExtra", name: "Persona_Id", newName: "PersonaId");
            RenameColumn(table: "dbo.Licencias", name: "Persona_Id", newName: "PersonaId");
            RenameColumn(table: "dbo.PermisosAvanzados", name: "Persona_Id", newName: "PersonaId");
            RenameColumn(table: "dbo.PermisosSimples", name: "Persona_Id", newName: "PersonaId");
            RenameColumn(table: "dbo.Prestamos", name: "Persona_Id", newName: "PersonaId");
            RenameIndex(table: "dbo.Asignaciones", name: "IX_Persona_Id", newName: "IX_PersonaId");
            RenameIndex(table: "dbo.Compensaciones", name: "IX_Persona_Id", newName: "IX_PersonaId");
            RenameIndex(table: "dbo.Licencias", name: "IX_Persona_Id", newName: "IX_PersonaId");
            RenameIndex(table: "dbo.PermisosAvanzados", name: "IX_Persona_Id", newName: "IX_PersonaId");
            RenameIndex(table: "dbo.PermisosSimples", name: "IX_Persona_Id", newName: "IX_PersonaId");
            RenameIndex(table: "dbo.Prestamos", name: "IX_Persona_Id", newName: "IX_PersonaId");
            AlterColumn("dbo.HorasExtra", "PersonaId", c => c.Int());
            CreateIndex("dbo.HorasExtra", "PersonaId");
            AddForeignKey("dbo.HorasExtra", "PersonaId", "dbo.Personal", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HorasExtra", "PersonaId", "dbo.Personal");
            DropIndex("dbo.HorasExtra", new[] { "PersonaId" });
            AlterColumn("dbo.HorasExtra", "PersonaId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Prestamos", name: "IX_PersonaId", newName: "IX_Persona_Id");
            RenameIndex(table: "dbo.PermisosSimples", name: "IX_PersonaId", newName: "IX_Persona_Id");
            RenameIndex(table: "dbo.PermisosAvanzados", name: "IX_PersonaId", newName: "IX_Persona_Id");
            RenameIndex(table: "dbo.Licencias", name: "IX_PersonaId", newName: "IX_Persona_Id");
            RenameIndex(table: "dbo.Compensaciones", name: "IX_PersonaId", newName: "IX_Persona_Id");
            RenameIndex(table: "dbo.Asignaciones", name: "IX_PersonaId", newName: "IX_Persona_Id");
            RenameColumn(table: "dbo.Prestamos", name: "PersonaId", newName: "Persona_Id");
            RenameColumn(table: "dbo.PermisosSimples", name: "PersonaId", newName: "Persona_Id");
            RenameColumn(table: "dbo.PermisosAvanzados", name: "PersonaId", newName: "Persona_Id");
            RenameColumn(table: "dbo.Licencias", name: "PersonaId", newName: "Persona_Id");
            RenameColumn(table: "dbo.HorasExtra", name: "PersonaId", newName: "Persona_Id");
            RenameColumn(table: "dbo.Compensaciones", name: "PersonaId", newName: "Persona_Id");
            RenameColumn(table: "dbo.Asignaciones", name: "PersonaId", newName: "Persona_Id");
            CreateIndex("dbo.HorasExtra", "Persona_Id");
            AddForeignKey("dbo.HorasExtra", "Persona_Id", "dbo.Personal", "Id", cascadeDelete: true);
        }
    }
}
