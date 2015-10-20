using FluentNHibernate;
using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVCTest.Repository.nHibernate.Helpers
{
    public class CustomForeignKeyConvention : ForeignKeyConvention
    {   
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
                return type.Name + "Id";  // many-to-many, one-to-many, join

            return property.Name + "Id"; // many-to-one
        }
    }
}