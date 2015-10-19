using MVCTest.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCTest.Repository.EF
{
    public class TrainingContext : DbContext
    {
        public TrainingContext() : base("name=TrainingEntities")
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public DbSet<PhoneType> PhoneTypes { get; set; }
    }
}