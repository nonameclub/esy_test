using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ESY.TEST.Startup))]
namespace ESY.TEST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
