using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TvSeriesApp.Startup))]
namespace TvSeriesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
