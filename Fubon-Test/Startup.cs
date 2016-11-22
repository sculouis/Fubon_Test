using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fubon_Test.Startup))]
namespace Fubon_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
