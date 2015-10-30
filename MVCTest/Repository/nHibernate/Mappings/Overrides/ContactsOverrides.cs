using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MVCTest.Repository.Entities;

namespace MVCTest.Repository.NHibernate.Mappings.Overrides
{
    /// <summary>
    /// The contact overrides.
    /// </summary>
    public class ContactOverrides : IAutoMappingOverride<Contact>
    {
        /// <summary>
        /// The override.
        /// </summary>
        /// <param name="mapping">
        /// The mapping.
        /// </param>
        public void Override(AutoMapping<Contact> mapping)
        {
            //mapping.IgnoreProperty(p => p.HomePhone);
            //mapping.IgnoreProperty(p => p.CellPhone);
            //mapping.IgnoreProperty(p => p.WorkPhone);
            ////mapping(p => p.PhoneCollectionToFlatObject);
        }
    }
}