
namespace Training.Controllers {
    export interface IContact {
        firstName?: string;
        lastName?: string;
        address?: string;
        city?: string;
        state?: string;
        zip?: number;
        homePhone?: number;
        cellPhone?: number;
        workPhone?: number;
    }


    export class Contact implements IContact {
        public firstName: string;
        public lastName: string;
        public address: string;
        public city: string;
        public state: string;
        public zip: number;
        public homePhone: number;
        public cellPhone: number;
        public workPhone: number;
        public showDetails: boolean;
        public isEditing: boolean;
        public editContact: IContact;

        constructor(contact: IContact) {
            if (contact == null) {
                contact = {};
            }
            this.assignProperties(contact, this);
            this.isEditing = false;
            this.showDetails = false;
        }


        public createNewIContact = (): IContact => {
            var tempIContact: IContact =
                {
                    firstName: "",
                    lastName: "",
                    address: "",
                    city: "",
                    state: "",
                    zip: null,
                    homePhone: null,
                    cellPhone: null,
                    workPhone: null,
                };

            return tempIContact;
        }

        public activeEditing = () => {
            //console.log("activeEditing");
            if (this) {
                return this.isEditing;
            }
            else {
                return false;
            }
        }

        public toggleShowDetails = () => {
            //console.log("show details");
            this.showDetails = !this.showDetails;
        }

        public assignProperties = (source: IContact, dest: IContact) => {
          
            //This doesnt work here because of ByRef. A new object gets created and messes it up.
            //if (this.dest == null) {
            //    this.dest = this.createBlankInstance();
            //}


            //This doesnt work here because it assigns other properties also.
            //for (var prop in source) {                
            //    if (source.hasOwnProperty(prop)) {
            //        dest[prop] = source[prop];
            //    }
            //}

            dest.firstName = source.firstName;
            dest.lastName = source.lastName;
            dest.address = source.address;
            dest.city = source.city;
            dest.state = source.state;
            dest.zip = source.zip;
            dest.homePhone = source.homePhone;
            dest.cellPhone = source.cellPhone;
            dest.workPhone = source.workPhone;
        }


    }


    export class ListController {

        constructor(private $scope) {
            console.log("constructor");
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

        public deleteContact = (contact: Contact) => {
            var index = this.contacts.indexOf(contact);
            this.contacts.splice(index, 1);

        }

        public toggleAddMode = (contact: Contact, isDirty: boolean) => {

            if (!contact) { //clicked on Add Button  
                contact = new Contact(null);              
                this.$scope.newContact = contact;
            }
            else if (isDirty) { //Save
                this.contacts.push(new Contact(contact.editContact));                
                this.$scope.newContact = null;
            }
            else { //Cancel
                this.$scope.newContact = null;
            }
            contact.isEditing = !contact.isEditing;
        }

        public toggleEditMode = (contact: Contact, isDirty: boolean) => {
            contact.isEditing = !contact.isEditing;

            if (contact.isEditing) {
                //this.editContact = <IContact>this;
                if (contact.editContact == null) {
                    contact.editContact = contact.createNewIContact();
                }
                contact.assignProperties(contact, contact.editContact);
            }
            else {
                contact.assignProperties(contact.editContact, contact);
            }
        }

        public getButtonText = (contact: Contact, dirty: boolean, mode: string) => {
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

        public contacts =
        [
            new Contact({
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
            new Contact({
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
            new Contact({
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
            new Contact({
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

    angular.module("contactsApp").controller("listCtrl", Training.Controllers.ListController);


}