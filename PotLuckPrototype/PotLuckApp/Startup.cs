using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PotLuckApp.Startup))]
namespace PotLuckApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
