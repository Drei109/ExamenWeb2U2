namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AsignacionesTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asignaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mes = c.DateTime(nullable: false, storeType: "date"),
                        Total = c.Decimal(nullable: false, storeType: "money"),
                        Estado = c.String(maxLength: 255),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personal", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asignaciones", "Persona_Id", "dbo.Personal");
            DropIndex("dbo.Asignaciones", new[] { "Persona_Id" });
            DropTable("dbo.Asignaciones");
        }
    }
}
