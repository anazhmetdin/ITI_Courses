using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoIdentity.Startup))]
namespace AutoIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
