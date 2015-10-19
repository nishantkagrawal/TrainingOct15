using System;
using System.Collections.Generic;

namespace MVCTest.Repository.Entities
{
    public partial class PhoneType : IEntity
    {
        #region  .ctor
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhoneType()
        {
            //this.PhoneNumbers = new HashSet<PhoneNumber>();
        }
        #endregion


        public virtual int Id { get; set; }
        public virtual string Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
