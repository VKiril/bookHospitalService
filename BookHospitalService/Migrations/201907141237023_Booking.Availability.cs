namespace BookHospitalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingAvailability : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingModels", "Patient_Id", "dbo.PatientModels");
            DropIndex("dbo.BookingModels", new[] { "Patient_Id" });
            RenameColumn(table: "dbo.BookingModels", name: "Patient_Id", newName: "PatientModel_Id");
            AddColumn("dbo.BookingModels", "Availability_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.BookingModels", "PatientModel_Id", c => c.Int());
            CreateIndex("dbo.BookingModels", "Availability_Id");
            CreateIndex("dbo.BookingModels", "PatientModel_Id");
            AddForeignKey("dbo.BookingModels", "Availability_Id", "dbo.AvailabilityModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookingModels", "PatientModel_Id", "dbo.PatientModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingModels", "PatientModel_Id", "dbo.PatientModels");
            DropForeignKey("dbo.BookingModels", "Availability_Id", "dbo.AvailabilityModels");
            DropIndex("dbo.BookingModels", new[] { "PatientModel_Id" });
            DropIndex("dbo.BookingModels", new[] { "Availability_Id" });
            AlterColumn("dbo.BookingModels", "PatientModel_Id", c => c.Int(nullable: false));
            DropColumn("dbo.BookingModels", "Availability_Id");
            RenameColumn(table: "dbo.BookingModels", name: "PatientModel_Id", newName: "Patient_Id");
            CreateIndex("dbo.BookingModels", "Patient_Id");
            AddForeignKey("dbo.BookingModels", "Patient_Id", "dbo.PatientModels", "Id", cascadeDelete: true);
        }
    }
}
