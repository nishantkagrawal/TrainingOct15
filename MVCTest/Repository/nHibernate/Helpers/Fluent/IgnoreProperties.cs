using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace MVCTest.Repository.NHibernate.Helpers.Fluent
{
    /// <summary>
    /// The ignore properties.
    /// </summary>
    public static class IgnoreProperties
    {
        /// <summary>
        /// Ignore a single property.
        ///     Property marked with this attributes will no be persisted to table.
        /// </summary>
        /// <param name="p">
        /// <see cref="IPropertyIgnorer"/> interface
        /// </param>
        /// <param name="propertyType">
        /// <see cref="Type"/> of property
        /// </param>
        /// <returns>
        /// The property to ignore.
        /// </returns>
        public static IPropertyIgnorer SkipProperty(this IPropertyIgnorer p, Type propertyType)
        {
            return p.IgnoreProperties(x => x.MemberInfo.GetCustomAttributes(propertyType, false).Length > 0);
        }

        /// <summary>
        /// The should ignore member.
        /// </summary>
        /// <param name="member">
        /// The member.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool ShouldIgnoreMember(Member member)
        {
            if (member.IsProperty)
            {
                var prop = member.DeclaringType.GetProperty(member.Name);
                var test = Attribute.IsDefined(prop, typeof(NotMappedAttribute));
                return test;
            }

            return false;
        }
    }
}