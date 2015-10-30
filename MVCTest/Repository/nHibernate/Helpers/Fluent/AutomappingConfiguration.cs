using System;
using FluentNHibernate.Automapping;
using MVCTest.Helpers;
using MVCTest.Repository.NHibernate.Helpers.MapByCode;

namespace MVCTest.Repository.NHibernate.Helpers.Fluent
{
    /// <summary>
    ///     Configures and register mappings of  Models with NHibernate
    /// </summary>
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        /// <summary>
        /// Maps all Models implementing IEntity, and not implementing IFluentIgnore and IMapByCode
        /// </summary>
        /// <param name="type">
        /// The type of model currently being checked
        /// </param>
        /// <returns>
        /// Whether the current type should be automapped or not
        /// </returns>
        public override bool ShouldMap(Type type)
        {
            return
                type.GetInterface(typeof(IEntity).FullName) != null &&
                !type.HasAttribute(typeof(FluentIgnoreAttribute)) &&
                !type.HasAttribute(typeof(MapByCodeAttribute));
        }
    }
}