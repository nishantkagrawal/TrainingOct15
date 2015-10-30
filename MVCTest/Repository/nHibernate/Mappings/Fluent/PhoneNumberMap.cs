using FluentNHibernate.Mapping;
using MVCTest.Repository.Entities;

namespace MVCTest.Repository.NHibernate.Mappings.Fluent
{
    /// <summary>
    /// The phone number map.
    /// </summary>
    public class PhoneNumberMap : ClassMap<PhoneNumber>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberMap"/> class.
        /// </summary>
        public PhoneNumberMap()
        {
            this.Id(x => x.Id);
            this.Map(x => x.Number);
            this.References(x => x.PhoneType).Column("PhoneTypeId");
            this.References(x => x.Contact).Column("ContactId");
        }
    }
}