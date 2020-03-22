using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stavochka.Startup))]
namespace Stavochka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
