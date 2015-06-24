using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyStoryWeb.Startup))]
namespace MyStoryWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
