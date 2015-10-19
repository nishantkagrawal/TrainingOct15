using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace MVCTest.Repository.Entities
{
    
    public partial class Contact : IEntity
    {
        #region .ctor
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contact()
        {
            //this.PhoneNumbers = new HashSet<PhoneNumber>();
        }

        #endregion

        #region Database Columns

        [JsonProperty(PropertyName = "id")]
        public virtual int Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public virtual string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public virtual string LastName { get; set; }

        [JsonProperty(PropertyName = "address")]
        public virtual string Address { get; set; }

        [JsonProperty(PropertyName = "city")]
        public virtual string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public virtual string State { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public virtual string Zip { get; set; }

        #endregion

        #region Foreign Keys

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        [XmlIgnore]
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        #endregion

        #region Non-Db Properties       

        [JsonProperty(PropertyName = "homePhone")]
        [NotMapped]
        public virtual string HomePhone { get; set; }

        [JsonProperty(PropertyName = "workPhone")]
        [NotMapped]
        public virtual string WorkPhone { get; set; }

        [JsonProperty(PropertyName = "cellPhone")]
        [NotMapped]
        public virtual string CellPhone { get; set; }

        #endregion

        #region Helper Methods
        public virtual Contact PhoneCollectionToFlatObject()
        {
            this.HomePhone = this.PhoneNumbers?.FirstOrDefault(p => p.PhoneType.Type == "Home")?.Number;
            this.WorkPhone = this.PhoneNumbers?.FirstOrDefault(p => p.PhoneType.Type == "Work")?.Number;
            this.CellPhone = this.PhoneNumbers?.FirstOrDefault(p => p.PhoneType.Type == "Cell")?.Number;

            return this;
        }


        public virtual List<PhoneNumber> FlatObjectToPhoneCollection()
        {
            List<PhoneNumber> phoneNumbers = null;
            if (this.HomePhone != null || this.WorkPhone != null || this.CellPhone != null)
            {
                phoneNumbers = new List<PhoneNumber>();
                if (this.HomePhone != null)
                {
                    PhoneNumber phoneNumber = CreatePhoneNumber(this.HomePhone, 1);
                    phoneNumbers.Add(phoneNumber);
                }

                if (this.WorkPhone != null)
                {
                    PhoneNumber phoneNumber = CreatePhoneNumber(this.WorkPhone, 2);
                    phoneNumbers.Add(phoneNumber);
                }

                if (this.CellPhone != null)
                {
                    PhoneNumber phoneNumber = CreatePhoneNumber(this.CellPhone, 3);
                    phoneNumbers.Add(phoneNumber);
                }
            }

            return phoneNumbers;
        }

        private PhoneNumber CreatePhoneNumber(string phoneNumber, int type)
        {
            return new PhoneNumber()
            {
                ContactId = this.Id,
                PhoneTypeId = type,
                Number = phoneNumber
            };
        }

        #endregion
    }
}
