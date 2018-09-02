using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafePoint.Startup))]
namespace SafePoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
