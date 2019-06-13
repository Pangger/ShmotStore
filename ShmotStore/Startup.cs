using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShmotStore.Startup))]
namespace ShmotStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
