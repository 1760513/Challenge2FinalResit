using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PotLuckPrototype.Startup))]
namespace PotLuckPrototype
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
