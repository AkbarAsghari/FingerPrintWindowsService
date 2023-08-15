using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

namespace FingerPrintService
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Configure Web API for self-host. 
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(false);

            appBuilder.UseCors(CorsOptions.AllowAll);

            appBuilder.UseWebApi(config);
        }
    }
}
