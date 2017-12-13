using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SerdarBlog.Startup))]
namespace SerdarBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
