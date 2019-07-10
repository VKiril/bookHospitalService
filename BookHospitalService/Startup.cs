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
        }
    }
}
