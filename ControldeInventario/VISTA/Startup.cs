using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VISTA.Startup))]
namespace VISTA
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
