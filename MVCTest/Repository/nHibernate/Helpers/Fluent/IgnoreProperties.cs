using FluentNHibernate;
using FluentNHibernate.Automapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTest.Repository.nHibernate.Helpers
{
    public static class FluentIgnore
    {
        /// <summary>
        /// Ignore a single property.
        /// Property marked with this attributes will no be persisted to table.
        /// </summary>
        /// <param name="p">IPropertyIgnorer</param>
        /// <param name="propertyType">The type to ignore.</param>
        /// <returns>The property to ignore.</returns>
        public static IPropertyIgnorer SkipProperty(this IPropertyIgnorer p, Type propertyType)
        {
            return p.IgnoreProperties(x => x.MemberInfo.GetCustomAttributes(propertyType, false).Length > 0);            
        }

        static bool ShouldIgnoreMember(Member member)
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