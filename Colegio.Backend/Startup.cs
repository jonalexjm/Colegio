using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Colegio.Backend.Startup))]
namespace Colegio.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
