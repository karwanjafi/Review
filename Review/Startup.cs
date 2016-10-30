using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Review.Startup))]
namespace Review
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
