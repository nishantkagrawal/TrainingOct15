using MVCTest.Repository.NHibernate.Helpers.Fluent;

namespace MVCTest.Repository.Entities
{
    /// <summary>
    /// The phone number.
    /// </summary>
    [FluentIgnore]
    public class PhoneNumber : IEntity
    {
        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public virtual Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the contact id.
        /// </summary>
        public virtual int ContactId { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public virtual string Number { get; set; }

        /// <summary>
        /// Gets or sets the phone type.
        /// </summary>
        public virtual PhoneType PhoneType { get; set; }

        /// <summary>
        /// Gets or sets the phone type id.
        /// </summary>
        public virtual int PhoneTypeId { get; set; }
    }
}