using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movie_Rentals.Startup))]
namespace Movie_Rentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
