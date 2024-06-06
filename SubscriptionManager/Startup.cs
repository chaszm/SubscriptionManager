using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SubscriptionManager.Startup))]
namespace SubscriptionManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
