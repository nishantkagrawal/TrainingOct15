using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace MVCTest.Repository.Entities
{
    /// <summary>
    /// The contact.
    /// </summary>
    public class Contact : IEntity
    {
        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", 
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contact()
        {
            //this.PhoneNumbers = new HashSet<PhoneNumber>();
        }

        #endregion .ctor

        #region Foreign Keys

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", 
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        [XmlIgnore]
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        #endregion Foreign Keys

        #region Database Columns

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public virtual string Address { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public virtual string City { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public virtual string State { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        [JsonProperty(PropertyName = "zip")]
        public virtual string Zip { get; set; }

        #endregion Database Columns

        #region Non-Db Properties

        /// <summary>
        /// Gets or sets the cell phone.
        /// </summary>
        [JsonProperty(PropertyName = "cellPhone")]
        [NotMapped]
        public virtual string CellPhone { get; set; }

        /// <summary>
        /// Gets or sets the home phone.
        /// </summary>
        [JsonProperty(PropertyName = "homePhone")]
        [NotMapped]
        public virtual string HomePhone { get; set; }

        /// <summary>
        /// Gets or sets the work phone.
        /// </summary>
        [JsonProperty(PropertyName = "workPhone")]
        [NotMapped]
        public virtual string WorkPhone { get; set; }
        #endregion Non-Db Properties

        #region Helper Methods

        /// <summary>
        /// The flat object to phone collection.
        /// </summary>
        /// <returns>
        /// The <see cref="List{PhoneNumber}"/>.
        /// </returns>
        public virtual List<PhoneNumber> FlatObjectToPhoneCollection()
        {
            List<PhoneNumber> phoneNumbers = null;
            if (this.HomePhone == null && this.WorkPhone == null && this.CellPhone == null) return phoneNumbers;

            phoneNumbers = new List<PhoneNumber>();
            if (this.HomePhone != null)
            {
                var phoneNumber = this.CreatePhoneNumber(this.HomePhone, 1);
                phoneNumbers.Add(phoneNumber);
            }

            if (this.WorkPhone != null)
            {
                var phoneNumber = this.CreatePhoneNumber(this.WorkPhone, 2);
                phoneNumbers.Add(phoneNumber);
            }

            if (this.CellPhone != null)
            {
                var phoneNumber = this.CreatePhoneNumber(this.CellPhone, 3);
                phoneNumbers.Add(phoneNumber);
            }

            return phoneNumbers;
        }

        /// <summary>
        /// The phone collection to flat object.
        /// </summary>
        /// <returns>
        /// The <see cref="Contact"/>.
        /// </returns>
        public virtual Contact PhoneCollectionToFlatObject()
        {
            this.HomePhone = this.PhoneNumbers?.FirstOrDefault(p => p.PhoneType.Type == "Home")?.Number;
            this.WorkPhone = this.PhoneNumbers?.FirstOrDefault(p => p.PhoneType.Type == "Work")?.Number;
            this.CellPhone = this.PhoneNumbers?.FirstOrDefault(p => p.PhoneType.Type == "Cell")?.Number;

            return this;
        }
        /// <summary>
        /// The create phone number.
        /// </summary>
        /// <param name="phoneNumber">
        /// The phone number.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="PhoneNumber"/>.
        /// </returns>
        private PhoneNumber CreatePhoneNumber(string phoneNumber, int type)
        {
            return new PhoneNumber
            {
                ContactId = this.Id, 
                PhoneTypeId = type, 
                Number = phoneNumber
            };
        }

        #endregion Helper Methods
    }
}