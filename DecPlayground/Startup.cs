using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DecPlayground.Startup))]
namespace DecPlayground
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
