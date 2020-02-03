using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_LoginRegister.Startup))]
namespace MVC_LoginRegister
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
