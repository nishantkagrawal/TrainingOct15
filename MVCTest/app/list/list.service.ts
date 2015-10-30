namespace Training.Services {
    import TC = Training.Controllers;
    import TM = Training.Models;

    export interface IContactResource extends ng.resource.IResourceClass<TM.IContact> {
        create(contact: TM.IContact): any;
    }

    export class ContactsService {
        private resource: IContactResource;
        constructor(private $resource: ng.resource.IResourceService) {
            this.resource = <IContactResource>$resource("api/Contacts/:id",
                { id: "@id" },
                {
                    get: { method: "GET" },
                    save: { method: "PUT" },
                    query: { method: 'GET', isArray: true },
                    create: { method: 'POST' },
                    delete: { method: "Delete" }
                });
        }

        getAllContacts = () => {
            var query = this.resource.query();
            var contacts = new Array<TM.Contact>();
            query.$promise.then((results) => {
                //console.log(results);

                for (var i = 0; i < results.length; i++) {
                    //console.log(results[i]);
                    contacts.push(new TM.Contact(<TM.IContactBase>results[i]));
                }
            });

            return contacts;
        }

        getContact = (contactId) => {
            return this.resource.get(contactId);
        }

        saveContact = (contactId, contact: TM.IContactBase) => {
            return this.resource.save({ id: contactId }, contact);
        }

        createContact = (contact: TM.IContactBase) => {
            return this.resource.create(<TM.IContact>contact);
        }

        deleteContact = (contact: TM.IContactBase) => {
            console.log(contact.id);
            return this.resource.delete({ id: contact.id });
        }
    }

    angular.module("contactsApp").service("contactsService", ContactsService);
}