
namespace Training.Controllers {
    import TM = Training.Models;
    export class ListController {
        public contacts: TM.Contact[];
        constructor(private $scope, private $window: ng.IWindowService, private contactsService: Training.Services.ContactsService) {

            //this.contacts = contactsService.getAllContacts();
            this.contacts = contactsService.getAllContacts();
            //console.log(this.contacts);
        }

        public sortOrder = "lastName";

        public btnContent = "btnContent test";

        public forUnitTest = false;
        public testFunction = (input) => {
            this.forUnitTest = input;
            console.log(this.contacts);
        }

        public phoneNumberPattern = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/;

        
        //    var contact = new Contact(null);
        //    contact.isEditing = true;
        //    this.contacts.push(contact);
        //}        

        public deleteContact = (contact: TM.Contact) => {
            if (this.$window.confirm("Are you sure you want to delete?")) {
                this.contactsService.deleteContact(contact);
                var index = this.contacts.indexOf(contact);
                this.contacts.splice(index, 1);
            }

        }

        public toggleAddMode = (contact: TM.Contact, isDirty: boolean) => {

            if (!contact) { //clicked on Add Button  
                contact = new TM.Contact(null);
                this.$scope.newContact = contact;
            }
            else if (isDirty) { //Save
                var contactToSave = new TM.Contact(contact.editContact);
                this.contacts.push(contactToSave);
                this.contactsService.createContact(contactToSave);
                this.$scope.newContact = null;
            }
            else { //Cancel
                this.$scope.newContact = null;
            }
            contact.isEditing = !contact.isEditing;
        }

        public toggleEditMode = (contact: TM.Contact, isDirty: boolean) => {

            if (contact.isEditing == false) { //Clicked on Edit, start editing
                //this.editContact = <IContact>this;
                if (contact.editContact == null) {
                    contact.editContact = contact.createNewIContact();
                }
                contact.assignProperties(contact, contact.editContact);
                contact.isEditing = true;
            }
            else {
                if (isDirty) //editing and dirty, save the contact
                {
                    contact.assignProperties(contact.editContact, contact);
                    contact.editContact = null;
                    this.contactsService.saveContact(contact.id, contact);
                }
                else {  //editing and not dirty, cancel
                    //do nothing
                }
                contact.isEditing = false;
            }

        }

        public getButtonText = (contact: TM.Contact, dirty: boolean, mode: string) => {
            //console.log("getEditText");
            
            if (contact && contact.isEditing) {
                if (dirty) {
                    return "Save";
                }
                else {
                    return "Cancel";
                }
            }
            else {
                return mode;
            }
        }

        //public contacts =
        //[
        //    new Contact({
        //        firstName: "John",
        //        lastName: "Lennon",
        //        address: "123 Strawberry Fields",
        //        city: "Forever",
        //        state: "UK",
        //        zip: 12344,
        //        homePhone: 2121112221,
        //        cellPhone: 2121112222,
        //        workPhone: 2121112223
        //    }),
        //    new Contact({
        //        firstName: "Paul",
        //        lastName: "McCartney",
        //        address: "456 Penny Lane",
        //        city: "London",
        //        state: "UK",
        //        zip: 55423,
        //        homePhone: 2122222221,
        //        cellPhone: 2122222222,
        //        workPhone: 2122222223
        //    }),
        //    new Contact({
        //        firstName: "George",
        //        lastName: "Harrison",
        //        address: "141 Something",
        //        city: "London",
        //        state: "UK",
        //        zip: 55627,
        //        homePhone: 2123332221,
        //        cellPhone: 2123332222,
        //        workPhone: 2123332223
        //    }),
        //    new Contact({
        //        firstName: "Ringo",
        //        lastName: "Starr",
        //        address: "1669 Octopus' Garden",
        //        city: "New York",
        //        state: "NY",
        //        zip: 12345,
        //        homePhone: 2124442221,
        //        cellPhone: 2124442222,
        //        workPhone: 2124442223
        //    })
        //];
    }

    angular.module("contactsApp").controller("listCtrl", Training.Controllers.ListController);


}