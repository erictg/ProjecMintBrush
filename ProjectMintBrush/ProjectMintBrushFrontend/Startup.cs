using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectMintBrushFrontend.Startup))]
namespace ProjectMintBrushFrontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
        }
    }
}
