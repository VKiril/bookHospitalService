namespace BookHospitalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingModelCreatedAt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstLastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Notices = c.String(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.BookingModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                        Procedure_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorModels", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.PatientModels", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProcedureModels", t => t.Procedure_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.Procedure_Id);
            
            CreateTable(
                "dbo.DoctorModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ProcedureModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        Doctor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorModels", t => t.Doctor_Id)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientModels", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookingModels", "Procedure_Id", "dbo.ProcedureModels");
            DropForeignKey("dbo.BookingModels", "Patient_Id", "dbo.PatientModels");
            DropForeignKey("dbo.BookingModels", "Doctor_Id", "dbo.DoctorModels");
            DropForeignKey("dbo.DoctorModels", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProcedureModels", "Doctor_Id", "dbo.DoctorModels");
            DropIndex("dbo.ProcedureModels", new[] { "Doctor_Id" });
            DropIndex("dbo.DoctorModels", new[] { "User_Id" });
            DropIndex("dbo.BookingModels", new[] { "Procedure_Id" });
            DropIndex("dbo.BookingModels", new[] { "Patient_Id" });
            DropIndex("dbo.BookingModels", new[] { "Doctor_Id" });
            DropIndex("dbo.PatientModels", new[] { "User_Id" });
            DropTable("dbo.ProcedureModels");
            DropTable("dbo.DoctorModels");
            DropTable("dbo.BookingModels");
            DropTable("dbo.PatientModels");
        }
    }
}
