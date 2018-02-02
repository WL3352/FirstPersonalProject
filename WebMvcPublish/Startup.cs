using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMvcPublish.Startup))]
namespace WebMvcPublish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
