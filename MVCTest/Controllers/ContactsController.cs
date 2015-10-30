using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCTest.Repository;
using MVCTest.Repository.Entities;

namespace MVCTest.Controllers
{
    /// <summary>
    ///     The contacts controller.
    /// </summary>
    public class ContactsController : ApiController
    {
        /// <summary>
        ///     The unit of work.
        /// </summary>
        private readonly IUnitOfWork uOw;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsController"/> class.
        /// </summary>
        /// <param name="uow">
        /// The uow.
        /// </param>
        public ContactsController(IUnitOfWork uow)
        {
            this.uOw = uow;
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        [HttpDelete]
        public void Delete(int id)
        {
            var contactToRemove = this.uOw.Contacts.GetAll().Single(p => p.Id == id);
            var phonesToRemove = contactToRemove.PhoneNumbers;
            this.uOw.PhoneNumbers?.Delete(phonesToRemove);
            this.uOw.Contacts.Delete(contactToRemove);
            this.uOw.SaveChanges();
        }

        // GET api/<controller>
        /// <summary>
        ///     The get.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerable{Contact}" />.
        /// </returns>
        public IEnumerable<Contact> Get()
        {
            return
                this.uOw.Contacts.GetAll()
                    .Include(p => p.PhoneNumbers)
                    .AsEnumerable()
                    .Select(p => p.PhoneCollectionToFlatObject()); //return contacts;
        }

        // GET api/<controller>/5
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Contact"/>.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Returns exception if the id is less than 0
        /// </exception>
        public Contact Get(int id)
        {
            if (id < 0)
            {
                throw new IndexOutOfRangeException();
            }

            //if (id > contacts.Count)
            //    return default(Contact);
            return this.uOw.Contacts.GetAll()
                .Include(p => p.PhoneNumbers)
                .Single(p => p.Id == id)
                .PhoneCollectionToFlatObject();
        }

        // POST api/<controller>
        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="HttpResponseException">
        /// Http Response Exception
        /// </exception>
        public void Post([FromBody] Contact value)
        {
            if (ValidateContact(value))
            {
                this.uOw.Contacts.Add(value);
                value.PhoneNumbers = value.FlatObjectToPhoneCollection();

                this.uOw.SaveChanges();
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "Tried to add invalid contact"
                };
                throw new HttpResponseException(response);
            }
        }

        // PUT api/<controller>/5
        /// <summary> The put. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="value"> The Contact value to PUT. </param>
        /// <returns>The contact value back</returns>
        public Contact Put(int id, [FromBody] Contact value)
        {
            if (!ValidateContact(value))
            {
                return null;
            }

            var contactToUpdate = this.uOw.Contacts.GetAll().SingleOrDefault(c => c.Id == id);
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

            this.uOw.SaveChanges();
            return contactToUpdate;
        }

        /// <summary>
        /// The validate contact.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool ValidateContact(Contact value)
        {
            return !string.IsNullOrWhiteSpace(value.FirstName);
        }
    }
}