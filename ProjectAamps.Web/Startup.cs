using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AAMPS.Web.Startup))]
namespace AAMPS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
