using MVCTest.Repository.Entities;

namespace MVCTest.Repository
{
// The file is kept separate so that the kernel is abstracted from
    // the user interacted file

    /// <summary>
    ///     Interface to define all repositories.
    /// </summary>
    public interface IUnitOfWorkRepositories
    {
        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        IRwRepository<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        IRwRepository<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the phone types.
        /// </summary>
        IRwRepository<PhoneType> PhoneTypes { get; set; }
    }
}