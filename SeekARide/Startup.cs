using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeekARide.Startup))]
namespace SeekARide
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
