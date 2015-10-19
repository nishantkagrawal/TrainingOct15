using MVCTest.Models;
using MVCTest.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTest.Repository
{
    //The file is kept separate so that the kernel is abstracted from
    //the user interacted file

    /// <summary>
    /// Interface to define all repositories.
    /// </summary>
    public interface IUnitOfWorkRepositories
    {
        IRWRepository<Contact> Contacts { get; set; }
        IRWRepository<PhoneNumber> PhoneNumbers { get; set; }
        IRWRepository<PhoneType> PhoneTypes { get; set; }

    }
}
