namespace Training.Services.Mock {
    import TC = Training.Controllers;
    import TM = Training.Models;

    export class ContactsMockService {
        constructor() {
        }

        getAllContacts = () => {
            return this.contacts;
        }

        getContact = (contactId) => {
            //return this.resource.get(contactId);
        }

        saveContact = (contactId, contact) => {
            //return this.resource.save(contact);
        }

        deleteContact = (contact) => {
            console.log(contact.id);
            //return this.resource.delete({ id: contact.Id });
        }

        private contacts =
        [
            new TM.Contact({
                firstName: "John",
                lastName: "Lennon",
                address: "123 Strawberry Fields",
                city: "Forever",
                state: "UK",
                zip: 12344,
                homePhone: 2121112221,
                cellPhone: 2121112222,
                workPhone: 2121112223
            }),
            new TM.Contact({
                firstName: "Paul",
                lastName: "McCartney",
                address: "456 Penny Lane",
                city: "London",
                state: "UK",
                zip: 55423,
                homePhone: 2122222221,
                cellPhone: 2122222222,
                workPhone: 2122222223
            }),
            new TM.Contact({
                firstName: "George",
                lastName: "Harrison",
                address: "141 Something",
                city: "London",
                state: "UK",
                zip: 55627,
                homePhone: 2123332221,
                cellPhone: 2123332222,
                workPhone: 2123332223
            }),
            new TM.Contact({
                firstName: "Ringo",
                lastName: "Starr",
                address: "1669 Octopus' Garden",
                city: "New York",
                state: "NY",
                zip: 12345,
                homePhone: 2124442221,
                cellPhone: 2124442222,
                workPhone: 2124442223
            })
        ];
    }
}