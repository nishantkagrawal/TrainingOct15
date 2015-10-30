using System.Web.Mvc;

namespace MVCTest
{
    /// <summary>
    /// Configuration class for global filters.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Static method for global filter registration.
        /// </summary>
        /// <param name="filters"><see cref="GlobalFilterCollection"/> to register filters in.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}