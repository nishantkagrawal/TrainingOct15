using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace MVCTest.Repository.NHibernate.Helpers.Fluent
{
    /// <summary>
    ///     Custom foreign key convention
    /// </summary>
    public class CustomForeignKeyConvention : ForeignKeyConvention
    {
        /// <summary>
        /// Override default convention. Use [TableName] + Id
        /// </summary>
        /// <param name="property">
        /// Name of the property
        /// </param>
        /// <param name="type">
        /// Name of the current type
        /// </param>
        /// <returns>
        /// The foreign key property name
        /// </returns>
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
            {
                return type.Name + "Id"; // many-to-many, one-to-many, join
            }

            return property.Name + "Id"; // many-to-one
        }
    }
}