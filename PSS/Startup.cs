using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PSS.Startup))]
namespace PSS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
