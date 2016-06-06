using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaStreamingProject.Startup))]
namespace MediaStreamingProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
