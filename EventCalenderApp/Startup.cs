using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventCalenderApp.Startup))]
namespace EventCalenderApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
