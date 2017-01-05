using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AWSBucket.Startup))]
namespace AWSBucket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
