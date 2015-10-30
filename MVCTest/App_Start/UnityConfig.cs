using System;
using System.Web.Http;
using Microsoft.Practices.Unity;
using MVCTest.Helpers;
using MVCTest.Repository;

namespace MVCTest
{
    /// <summary>
    /// Specifies the Unity Configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container

        /// <summary>
        /// Static property to hold the IUnityContainer
        /// </summary>
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
       {
           var container = new UnityContainer();
           RegisterTypes(container);
           GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
           return container;
       });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        /// <returns>The container which is configured</returns>
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        #endregion Unity Container

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container
                .RegisterType<IUnitOfWork, MVCTest.Repository.NHibernate.UnitOfWork>()
                 .RegisterInstance<IUnityContainer>(container);
        }
    }
}