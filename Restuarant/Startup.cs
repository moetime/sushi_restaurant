using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restuarant.Startup))]
namespace Restuarant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
