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
#if DEBUG
            using (var context = new Review.Model.CodeFirst.Models.ReviewModel())
                context.Database.CreateIfNotExists();
#endif
            ConfigureAuth(app);
        }
    }
}
