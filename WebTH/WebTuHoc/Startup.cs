using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTuHoc.Startup))]
namespace WebTuHoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
