using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaxCalulator.Startup))]
namespace TaxCalulator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
