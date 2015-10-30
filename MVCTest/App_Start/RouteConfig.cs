using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTest
{
    /// <summary>
    /// Configuration class for global routes.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Static method to register global filters
        /// </summary>
        /// <param name="routes"><see cref="RouteCollection"/> to register routes in</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}