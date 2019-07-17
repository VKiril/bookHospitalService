using BookHospitalService.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookHospitalService.Startup))]
namespace BookHospitalService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(UserRolesConstantMoldel.RoleDoctor))
            {
                var role = new IdentityRole
                {
                    Name = UserRolesConstantMoldel.RoleDoctor
                };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists(UserRolesConstantMoldel.RolePatient))
            {
                var role = new IdentityRole
                {
                    Name = UserRolesConstantMoldel.RolePatient
                };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists(UserRolesConstantMoldel.RoleAdmin))
            {
                var role = new IdentityRole
                {
                    Name = UserRolesConstantMoldel.RoleAdmin
                };
                roleManager.Create(role);
            }
        }
    }
}
