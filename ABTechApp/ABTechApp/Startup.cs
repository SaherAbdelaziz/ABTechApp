using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABTechApp.Startup))]
namespace ABTechApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
