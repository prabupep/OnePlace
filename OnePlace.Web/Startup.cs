using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnePlace.Web.Startup))]
namespace OnePlace.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
