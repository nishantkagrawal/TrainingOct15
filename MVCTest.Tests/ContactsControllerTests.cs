using Moq;
using MVCTest.Controllers;
using MVCTest.Models;
using MVCTest.Repository;
using MVCTest.Repository.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MVCTest.Tests
{
    [TestFixture]
    public class ContactsControllerTest
    {
        [Test]
        public void GetMethodReturnsCollections()
        {
            //arrange:           
            var testCtrl = new MockContactsRepository().Setup();

            //act:
            var result = testCtrl.Get();

            //assert:
            Assert.AreEqual(4, result.Count());
        }

        [Test(Description = "Passing a negative index should throw exception")]
        public void GetByNegativeShouldThrowException()
        {
            var testCtrl = new ContactsController(new Repository.EF.UnitOfWork());
            Assert.Throws<IndexOutOfRangeException>(() => testCtrl.Get(-1));
        }

        [Test]
        public void RetrieveASingleContactReturnsTheProperIndex()
        {
            //Arrange:
            var testCtrl = new MockContactsRepository().Setup();

            //Act:
            var result = testCtrl.Get(3);

            //Assert:
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void GettingAnInvalidIndexReturnsNull()
        {
            // Arrange:
            var testCtrl = new MockContactsRepository().Setup();

            // Act:
            var result = testCtrl.Get(600);

            // Assert:
            Assert.Null(result);

        }


        [Test]
        public void PostWithValidContactAddsToList()
        {
            // Arrange:
            var mockContactsRepository = new MockContactsRepository();
            var testCtrl = mockContactsRepository.Setup();
            var currentLength = testCtrl.Get().Count();

            // Act:
            var addition = new Contact()
            {
                FirstName = "Nishant",
                LastName = "Agrawal",
                Address = "123 Some Lane",
                City = "Exmouth",
                State = "UK",
                Zip = "83567"
            };

            testCtrl.Post(addition);
            mockContactsRepository.MockService.Verify(m => m.SaveChanges(), Times.Once());

            // Assert:
            var newCollection = testCtrl.Get();

            Assert.AreEqual(currentLength + 1, newCollection.Count());
            Assert.AreEqual(1, newCollection.Where(c => c == addition).Count());
        }

        [Test]
        public void PostWithBlankContactAddsToList()
        {
            // Arrange:
            var testCtrl = new MockContactsRepository().Setup();
            var currentLength = testCtrl.Get().Count();

            // Act:
            var addition = new Contact();
            Assert.Throws<HttpResponseException>(() => testCtrl.Post(addition));

            // Assert:
            var newCollection = testCtrl.Get();

            Assert.AreEqual(currentLength, newCollection.Count());
            Assert.AreEqual(0, newCollection.Where(c => c == addition).Count());
            
        }

        [Test]
        public void PutUpdatesAContact()
        {
            // Arrange:
            var testCtrl = new MockContactsRepository().Setup();
            var target = testCtrl.Get(1);

            // Act:
            target.LastName = "Agrawal";
            testCtrl.Put(1, new Contact()
            {
                FirstName = target.FirstName,
                LastName = "Agrawal",
                Address = target.Address,
                City = target.City,
                State = target.State,
                Zip = target.Zip,
                //HomePhone = target.HomePhone,
                //WorkPhone = target.WorkPhone,
                //CellPhone = target.CellPhone
            });
            

            // Assert:
            var updatedContact = testCtrl.Get(1);

            Assert.AreEqual("Agrawal", updatedContact.LastName);
        }

        [Test]
        public void DeleteAnExistingContactRemovesTheContact()
        {
            // Arrange:
            var mockRepo = new MockContactsRepository();
            var testCtrl = mockRepo.Setup();            

            Assert.AreEqual(1, testCtrl.Get().Where(c => c.Id == 2).Count());

            // Act:
            testCtrl.Delete(2);

            // Assert:
            var count = testCtrl.Get().Where(c => c.Id == 2).Count();

            Assert.AreEqual(0, count);

        }


    }
}
