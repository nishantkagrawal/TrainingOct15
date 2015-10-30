using System;
using MVCTest.Repository.Entities;

namespace MVCTest.Repository.NHibernate
{
    /// <summary>
    ///     The unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        public UnitOfWork()
        {
            this.Entities = new TrainingContext();
            this.Contacts = new Repository<Contact>(this.Entities.Session);
            this.PhoneNumbers = new Repository<PhoneNumber>(this.Entities.Session);
            this.PhoneTypes = new Repository<PhoneType>(this.Entities.Session);
        }

        /// <summary>
        ///     Gets or Sets the Entities.
        /// </summary>
        public TrainingContext Entities { get; }

        /// <summary>
        ///     Gets or sets the contacts.
        /// </summary>
        public IRwRepository<Contact> Contacts { get; set; }

        /// <summary>
        ///     Gets or sets the phone numbers.
        /// </summary>
        public IRwRepository<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        ///     Gets or sets the phone types.
        /// </summary>
        public IRwRepository<PhoneType> PhoneTypes { get; set; }

        /// <summary>
        ///     The begin transaction.
        /// </summary>
        public void BeginTransaction()
        {
            this.Entities.BeginTransaction();
        }

        /// <summary>
        ///     The commit.
        /// </summary>
        public void Commit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The roll back.
        /// </summary>
        public void RollBack()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The save changes.
        /// </summary>
        public void SaveChanges()
        {
        }
    }
}