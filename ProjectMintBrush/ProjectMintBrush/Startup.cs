using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectMintBrush.Startup))]
namespace ProjectMintBrush
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
