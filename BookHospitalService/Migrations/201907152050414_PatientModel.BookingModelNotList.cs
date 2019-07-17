namespace BookHospitalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientModelBookingModelNotList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingModels", "PatientModel_Id", "dbo.PatientModels");
            DropIndex("dbo.BookingModels", new[] { "PatientModel_Id" });
            AddColumn("dbo.PatientModels", "Booking_Id", c => c.Int());
            CreateIndex("dbo.PatientModels", "Booking_Id");
            AddForeignKey("dbo.PatientModels", "Booking_Id", "dbo.BookingModels", "Id");
            DropColumn("dbo.BookingModels", "PatientModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingModels", "PatientModel_Id", c => c.Int());
            DropForeignKey("dbo.PatientModels", "Booking_Id", "dbo.BookingModels");
            DropIndex("dbo.PatientModels", new[] { "Booking_Id" });
            DropColumn("dbo.PatientModels", "Booking_Id");
            CreateIndex("dbo.BookingModels", "PatientModel_Id");
            AddForeignKey("dbo.BookingModels", "PatientModel_Id", "dbo.PatientModels", "Id");
        }
    }
}
