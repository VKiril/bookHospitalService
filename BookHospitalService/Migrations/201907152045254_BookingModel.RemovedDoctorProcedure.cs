namespace BookHospitalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingModelRemovedDoctorProcedure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingModels", "Doctor_Id", "dbo.DoctorModels");
            DropForeignKey("dbo.BookingModels", "Procedure_Id", "dbo.ProcedureModels");
            DropIndex("dbo.BookingModels", new[] { "Doctor_Id" });
            DropIndex("dbo.BookingModels", new[] { "Procedure_Id" });
            DropColumn("dbo.BookingModels", "Doctor_Id");
            DropColumn("dbo.BookingModels", "Procedure_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingModels", "Procedure_Id", c => c.Int(nullable: false));
            AddColumn("dbo.BookingModels", "Doctor_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.BookingModels", "Procedure_Id");
            CreateIndex("dbo.BookingModels", "Doctor_Id");
            AddForeignKey("dbo.BookingModels", "Procedure_Id", "dbo.ProcedureModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookingModels", "Doctor_Id", "dbo.DoctorModels", "Id", cascadeDelete: true);
        }
    }
}
