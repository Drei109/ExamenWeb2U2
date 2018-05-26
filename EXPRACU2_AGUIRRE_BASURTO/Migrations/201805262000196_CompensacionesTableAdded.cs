namespace EXPRACU2_AGUIRRE_BASURTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompensacionesTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compensaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personal", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compensaciones", "Persona_Id", "dbo.Personal");
            DropIndex("dbo.Compensaciones", new[] { "Persona_Id" });
            DropTable("dbo.Compensaciones");
        }
    }
}
