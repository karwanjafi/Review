using Owin;

namespace IdentitySample
{
    public partial class Startup
    {
        public void CreateDatabse()
        {

        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
