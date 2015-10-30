using System.Collections.Generic;
using MVCTest.Repository.NHibernate.Helpers.MapByCode;

namespace MVCTest.Repository.Entities
{
    /// <summary>
    /// The phone type.
    /// </summary>
    [MapByCode]
    public class PhoneType : IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Navigational Property")]
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public virtual string Type { get; set; }
    }
}