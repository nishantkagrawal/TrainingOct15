using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MVCTest.Repository;
using MVCTest.Controllers;
using MVCTest.Repository.Entities;

namespace MVCTest.Tests
{
    public class MockContactsRepository
    {
        public List<Contact> contacts = new List<Contact>
               {
                    new Contact { Id = 1,
                        FirstName = "John",
                        LastName = "Lennon",
                        Address = "123 Strawberry Fields",
                        City = "Forever",
                        State = "UK",
                        Zip = "12344"
                    },
                    new Contact { Id = 2,
                        FirstName = "Paul",
                        LastName = "McCartney",
                        Address = "456 Penny Lane",
                        City = "London",
                        State = "UK",
                        Zip = "55423"
                    },
                    new Contact {Id = 3,
                        FirstName =  "George",
                        LastName = "Harrison",
                        Address = "141 Something",
                        City = "London",
                        State = "UK",
                        Zip = "55627"
                    },
                    new Contact { Id = 4,
                        FirstName = "Ringo",
                        LastName = "Starr",
                        Address = "1669 Octopus' Garden",
                        City = "New York",
                        State = "NY",
                        Zip = "12345"
                    }
                };

        public Mock<IUnitOfWork> MockService = new Mock<IUnitOfWork>();

        public ContactsController Setup()
        {
            MockService.Setup(srv => srv.Contacts.GetAll()).Returns(this.contacts.AsQueryable());


            MockService.Setup(srv => srv.Contacts.Add(It.IsAny<Contact>()))
                .Callback<Contact>(p => contacts.Add(p));

            MockService.Setup(srv => srv.Contacts.Delete(It.IsAny<Contact>()))
                .Callback<Contact>(p => contacts.Remove(p));


            MockService.Setup(m => m.SaveChanges()).Verifiable();

            return new ContactsController(MockService.Object);
            //mockService.Setup(srv => srv.PhoneNumbers.GetAll()).Returns(this..AsQueryable());

        }
    }
}
