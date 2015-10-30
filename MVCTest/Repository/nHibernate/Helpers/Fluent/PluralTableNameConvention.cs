using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace MVCTest.Repository.NHibernate.Helpers.Fluent
{
    /// <summary>
    /// The plural table name convention.
    /// </summary>
    public class PluralTableNameConvention : IClassConvention
    {
        /// <summary>
        /// The apply.
        /// </summary>
        /// <param name="instance">
        /// The instance.
        /// </param>
        public void Apply(IClassInstance instance)
        {
            instance.Table(Inflector.Inflector.Pluralize(instance.EntityType.Name));
        }
    }
}