using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PennHospitality.Startup))]
namespace PennHospitality
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
