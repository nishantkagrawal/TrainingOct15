using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MVCTest.Repository.Entities;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Repository.nHibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private TrainingContext entities = new TrainingContext();

        static UnitOfWork()
        {

        }
        public UnitOfWork()
        {
            this.Contacts = new Repository<Contact>(this.entities.Session);
            this.PhoneNumbers = new Repository<PhoneNumber>(this.entities.Session);
            this.PhoneTypes = new Repository<PhoneType>(this.entities.Session);

        }

        public IRWRepository<Contact> Contacts { get; set; }
        public IRWRepository<PhoneNumber> PhoneNumbers { get; set; }
        public IRWRepository<PhoneType> PhoneTypes { get; set; }

        public void BeginTransaction()
        {
            this.entities.BeginTransaction();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}