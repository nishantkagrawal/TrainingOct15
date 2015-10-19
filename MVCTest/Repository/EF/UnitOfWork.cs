using System;
using MVCTest.Models;
using MVCTest.Repository.Entities;

namespace MVCTest.Repository.EF
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private TrainingContext entities = new TrainingContext();

        static UnitOfWork()
        {
           
        }

        public UnitOfWork()
        {
            this.Contacts = new Repository<Contact>(entities.Contacts);
            this.PhoneNumbers = new Repository<PhoneNumber>(entities.PhoneNumbers);
            this.PhoneTypes = new Repository<PhoneType>(entities.PhoneTypes);

        }

        public IRWRepository<Contact> Contacts { get; set; }

        public IRWRepository<PhoneNumber> PhoneNumbers { get; set; }        
        public IRWRepository<PhoneType> PhoneTypes { get; set; }       

        //public ISession Session { get; set; }

        public void BeginTransaction()
        {
        }

        public void Commit()
        {            
        }

        public void RollBack()
        {         
        }

        public void SaveChanges()
        {
            this.entities.SaveChanges();
        }
    }
}