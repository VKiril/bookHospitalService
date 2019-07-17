namespace BookHospitalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorsAndProceduresMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorsAndProceduresModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Doctor_Id = c.Int(nullable: false),
                        Procedure_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorModels", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProcedureModels", t => t.Procedure_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Procedure_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorsAndProceduresModels", "Procedure_Id", "dbo.ProcedureModels");
            DropForeignKey("dbo.DoctorsAndProceduresModels", "Doctor_Id", "dbo.DoctorModels");
            DropIndex("dbo.DoctorsAndProceduresModels", new[] { "Procedure_Id" });
            DropIndex("dbo.DoctorsAndProceduresModels", new[] { "Doctor_Id" });
            DropTable("dbo.DoctorsAndProceduresModels");
        }
    }
}
