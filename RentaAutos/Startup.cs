using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentaAutos.Startup))]
namespace RentaAutos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
