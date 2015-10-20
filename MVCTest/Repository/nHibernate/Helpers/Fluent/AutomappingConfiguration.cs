using FluentNHibernate.Automapping;
using System;

namespace MVCTest.Repository.nHibernate.Helpers
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {

            return
                type.GetInterface(typeof(IEntity).FullName) != null &&
                type.GetInterface(typeof(IFluentIgnore).FullName) == null &&
                type.GetInterface(typeof(IMapByCode).FullName) == null;
        }
    }
}