using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using MVCTest.Repository;
using MVCTest.Repository.Entities;

namespace MVCTest.Controllers
{
    public class ContactsController : ApiController
    {

        private static List<Contact> contacts = new List<Contact>();
        IUnitOfWork uOW;

        //public ContactsController() : this(new Repository.nHibernate.UnitOfWork())
        //{
        //}

        public ContactsController(IUnitOfWork uow)
        {
            this.uOW = uow;
        }

        //static ContactsController()
        //{
        //    SetContacts();
        //}

        //private IQueryable<Contact> ContactsQuery()
        //{
        //    var query = entities.Contacts.Include(p => p.PhoneNumbers).Select(p => p.setPhoneNumbers());
        //    return query;
        //}

        // GET api/<controller>
        public IEnumerable<Contact> Get()
        {
            return uOW.Contacts.GetAll().Include(p => p.PhoneNumbers).AsEnumerable().Select(p => p.PhoneCollectionToFlatObject());            //return contacts;
        }

        // GET api/<controller>/5
        public Contact Get(int id)
        {
            if (id < 0)
                throw new IndexOutOfRangeException();

            //if (id > contacts.Count)
            //    return default(Contact);

            return this.uOW.Contacts.GetAll()
                .Include(p => p.PhoneNumbers)
                .Single(p => p.Id == id)
                .PhoneCollectionToFlatObject();
        }

        // POST api/<controller>
        public void Post([FromBody]Contact value)
        {
            if (validateContact(value))
            {
                this.uOW.Contacts.Add(value);
                value.PhoneNumbers = value.FlatObjectToPhoneCollection();

                this.uOW.SaveChanges();
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Tried to add invalid contact";
                throw new HttpResponseException(response);
            }

        }

        private bool validateContact(Contact value)
        {
            return !string.IsNullOrWhiteSpace(value.FirstName);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Contact value)
        {
            if (!validateContact(value))
                return;

            var contactToUpdate = this.uOW.Contacts.GetAll().SingleOrDefault(c => c.Id == id);
            if (contactToUpdate != null)
            {
                contactToUpdate.FirstName = value.FirstName;
                contactToUpdate.LastName = value.LastName;
                contactToUpdate.Address = value.Address;
                contactToUpdate.City = value.City;
                contactToUpdate.State = value.State;
                contactToUpdate.Zip = value.Zip;

                //TODO : Only add those numbers which are new                
                contactToUpdate.PhoneNumbers = value.FlatObjectToPhoneCollection();
                //contactToUpdate.HomePhone = value.HomePhone;
                //contactToUpdate.WorkPhone = value.WorkPhone;
                //contactToUpdate.CellPhone = value.CellPhone;
            }

            this.uOW.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            var contactToRemove = this.uOW.Contacts.GetAll().Single(p => p.Id == id);
            var phonesToRemove = contactToRemove.PhoneNumbers;
            if (this.uOW.PhoneNumbers != null)
            {
                this.uOW.PhoneNumbers.Delete(phonesToRemove);
            }
            this.uOW.Contacts.Delete(contactToRemove);
            this.uOW.SaveChanges();
        }

        //static void SetContacts()
        //{
        //    contacts.Add(new Contact()
        //    {
        //        FirstName = "John",
        //        LastName = "Lennon",
        //        Address = "123 Strawberry Fields",
        //        City = "Forever",
        //        State = "UK",
        //        Zip = "12344",
        //        HomePhone = "2121112221",
        //        CellPhone = "2121112222",
        //        WorkPhone = "2121112223"
        //    });
        //    contacts.Add(new Contact()
        //    {
        //        FirstName = "Paul",
        //        LastName = "McCartney",
        //        Address = "456 Penny Lane",
        //        City = "London",
        //        State = "UK",
        //        Zip = "55423",
        //        HomePhone = "2122222221",
        //        CellPhone = "2122222222",
        //        WorkPhone = "2122222223"
        //    });
        //    contacts.Add(new Contact()
        //    {
        //        FirstName = "George",
        //        LastName = "Harrison",
        //        Address = "141 Something",
        //        City = "London",
        //        State = "UK",
        //        Zip = "55627",
        //        HomePhone = "2123332221",
        //        CellPhone = "2123332222",
        //        WorkPhone = "2123332223"
        //    });
        //    contacts.Add(new Contact()
        //    {
        //        FirstName = "Ringo",
        //        LastName = "Starr",
        //        Address = "1669 Octopus' Garden",
        //        City = "New York",
        //        State = "NY",
        //        Zip = "12345",
        //        HomePhone = "2124442221",
        //        CellPhone = "2124442222",
        //        WorkPhone = "2124442223"
        //    });
        //}
    }
}