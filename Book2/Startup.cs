using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Book2.Startup))]
namespace Book2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
