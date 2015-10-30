using MVCTest.Repository.Entities;
using NHibernate.Mapping.ByCode.Conformist;

namespace MVCTest.Repository.NHibernate.Mappings
{
    /// <summary>
    /// The phone type map.
    /// </summary>
    public class PhoneTypeMap : ClassMapping<PhoneType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneTypeMap"/> class.
        /// </summary>
        public PhoneTypeMap()
        {
            this.Table("PhoneTypes");
            this.Id(x => x.Id);
            this.Property(x => x.Type);
            this.Bag(
                x => x.PhoneNumbers,
                cp =>
            {
                //cp.Key(k => k.Column(typeof(PhoneNumber).Name));
                //cp.Table("PhoneNumbers");
            },
                cr => cr.OneToMany(c => c.Class(typeof(PhoneNumber))));
        }
    }
}