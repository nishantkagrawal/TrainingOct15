using System;
using MVCTest.Repository.Entities;

namespace MVCTest.Repository.EF
{
    /// <summary>
    ///     The unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary> The Entities. </summary>
        private readonly TrainingContext entities = new TrainingContext();

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        public UnitOfWork()
        {
            this.Contacts = new Repository<Contact>(this.entities.Contacts);
            this.PhoneNumbers = new Repository<PhoneNumber>(this.entities.PhoneNumbers);
            this.PhoneTypes = new Repository<PhoneType>(this.entities.PhoneTypes);
        }

        /// <summary> Gets or sets the contacts. </summary>
        public IRwRepository<Contact> Contacts { get; set; }

        /// <summary> Gets or sets the phone numbers. </summary>
        public IRwRepository<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary> Gets or sets the phone types. </summary>
        public IRwRepository<PhoneType> PhoneTypes { get; set; }

        /// <summary> The begin transaction. </summary>
        public void BeginTransaction()
        {
        }

        //public ISession Session { get; set; }
        /// <summary> The commit. </summary>
        public void Commit()
        {
        }

        /// <summary>
        ///     The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(false);
        }

        /// <summary> The roll back. </summary>
        public void RollBack()
        {
        }

        /// <summary> The save changes. </summary>
        public void SaveChanges()
        {
            this.entities.SaveChanges();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The is disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free other state (managed objects).
                this.entities.Dispose();
            }

            // Free your own state (unmanaged objects).
            // Set large fields to null.
            this.disposed = true;
        }
    }
}