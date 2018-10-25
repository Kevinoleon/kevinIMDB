using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMDB.Startup))]
namespace IMDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
