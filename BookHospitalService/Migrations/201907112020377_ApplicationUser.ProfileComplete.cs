namespace BookHospitalService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserProfileComplete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsProfileCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsProfileCompleted");
        }
    }
}
