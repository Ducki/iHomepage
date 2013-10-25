using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iHomepage.Startup))]
namespace iHomepage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
