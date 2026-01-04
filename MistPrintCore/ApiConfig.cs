using Owin;
using System.Web.Http;

namespace MistPrintCore
{
    public class ApiConfig
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );

            app.UseWebApi(config);
        }
    }
}