using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameBacklog.Startup))]
namespace GameBacklog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
