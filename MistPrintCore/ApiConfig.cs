using Owin;
using System.Globalization;
using System.Web.Http;

namespace MistPrintCore
{
    public class ApiConfig
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Culture = CultureInfo.InvariantCulture;

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );

            app.UseWebApi(config);
        }
    }
}