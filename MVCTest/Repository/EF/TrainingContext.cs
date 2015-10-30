using System.Data.Entity;
using MVCTest.Repository.Entities;

namespace MVCTest.Repository.EF
{
    /// <summary>
    /// The training context.
    /// </summary>
    public class TrainingContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingContext"/> class.
        /// </summary>
        public TrainingContext() : base("name=TrainingEntities")
        {
        }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the phone types.
        /// </summary>
        public DbSet<PhoneType> PhoneTypes { get; set; }
    }
}