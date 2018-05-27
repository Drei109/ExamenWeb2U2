namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyInPersonaAdded : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Personal", name: "Turno_Id", newName: "TurnoId");
            RenameIndex(table: "dbo.Personal", name: "IX_Turno_Id", newName: "IX_TurnoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Personal", name: "IX_TurnoId", newName: "IX_Turno_Id");
            RenameColumn(table: "dbo.Personal", name: "TurnoId", newName: "Turno_Id");
        }
    }
}
