namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonaColumnInAsistenciaChanged1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Asistencias", "PersonaId", "dbo.Personal");
            DropIndex("dbo.Asistencias", new[] { "PersonaId" });
            AlterColumn("dbo.Asistencias", "PersonaId", c => c.Int());
            CreateIndex("dbo.Asistencias", "PersonaId");
            AddForeignKey("dbo.Asistencias", "PersonaId", "dbo.Personal", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asistencias", "PersonaId", "dbo.Personal");
            DropIndex("dbo.Asistencias", new[] { "PersonaId" });
            AlterColumn("dbo.Asistencias", "PersonaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Asistencias", "PersonaId");
            AddForeignKey("dbo.Asistencias", "PersonaId", "dbo.Personal", "Id", cascadeDelete: true);
        }
    }
}
