using System.Web.Http;

namespace MVCTest
{
    /// <summary>
    /// Class to register global WebAPI Configurations
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Static method to register WebAPI Configurations
        /// </summary>
        /// <param name="config"><see cref="HttpConfiguration"/> to register configurations in</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API Configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}