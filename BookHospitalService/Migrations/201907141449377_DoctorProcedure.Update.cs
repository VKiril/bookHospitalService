namespace BookHospitalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorProcedureUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProcedureModels", "Doctor_Id", "dbo.DoctorModels");
            DropIndex("dbo.ProcedureModels", new[] { "Doctor_Id" });
            DropColumn("dbo.ProcedureModels", "Doctor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProcedureModels", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.ProcedureModels", "Doctor_Id");
            AddForeignKey("dbo.ProcedureModels", "Doctor_Id", "dbo.DoctorModels", "Id");
        }
    }
}
