using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzaProject.Startup))]
namespace PizzaProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
