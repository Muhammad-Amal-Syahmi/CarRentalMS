using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarRentalMS.Startup))]
namespace CarRentalMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
