namespace BookHospitalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorModels", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorModels", "Category");
        }
    }
}
