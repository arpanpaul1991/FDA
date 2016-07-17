using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FDAWebsite.Startup))]
namespace FDAWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
