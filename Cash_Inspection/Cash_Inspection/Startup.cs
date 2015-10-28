using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cash_Inspection.Startup))]
namespace Cash_Inspection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
