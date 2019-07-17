namespace BookHospitalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvailabilityModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailabilityModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Interval = c.Int(nullable: false),
                        Doctor_Id = c.Int(),
                        Procedure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorModels", t => t.Doctor_Id)
                .ForeignKey("dbo.ProcedureModels", t => t.Procedure_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Procedure_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvailabilityModels", "Procedure_Id", "dbo.ProcedureModels");
            DropForeignKey("dbo.AvailabilityModels", "Doctor_Id", "dbo.DoctorModels");
            DropIndex("dbo.AvailabilityModels", new[] { "Procedure_Id" });
            DropIndex("dbo.AvailabilityModels", new[] { "Doctor_Id" });
            DropTable("dbo.AvailabilityModels");
        }
    }
}
