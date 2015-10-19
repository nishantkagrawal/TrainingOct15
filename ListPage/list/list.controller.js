var Training;
(function (Training) {
    var Controllers;
    (function (Controllers) {
        var Contact = (function () {
            function Contact(contact) {
                var _this = this;
                this.createNewIContact = function () {
                    var tempIContact = {
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
                };
                this.activeEditing = function () {
                    //console.log("activeEditing");
                    if (_this) {
                        return _this.isEditing;
                    }
                    else {
                        return false;
                    }
                };
                this.toggleShowDetails = function () {
                    //console.log("show details");
                    _this.showDetails = !_this.showDetails;
                };
                this.assignProperties = function (source, dest) {
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
                };
                if (contact == null) {
                    contact = {};
                }
                this.assignProperties(contact, this);
                this.isEditing = false;
                this.showDetails = false;
            }
            return Contact;
        })();
        Controllers.Contact = Contact;
        var ListController = (function () {
            function ListController($scope) {
                var _this = this;
                this.$scope = $scope;
                this.sortOrder = "lastName";
                this.btnContent = "btnContent test";
                this.forUnitTest = false;
                this.testFunction = function (input) {
                    _this.forUnitTest = input;
                    console.log(_this.contacts);
                };
                this.phoneNumberPattern = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/;
                //    var contact = new Contact(null);
                //    contact.isEditing = true;
                //    this.contacts.push(contact);
                //}        
                this.deleteContact = function (contact) {
                    var index = _this.contacts.indexOf(contact);
                    _this.contacts.splice(index, 1);
                };
                this.toggleAddMode = function (contact, isDirty) {
                    if (!contact) {
                        contact = new Contact(null);
                        _this.$scope.newContact = contact;
                    }
                    else if (isDirty) {
                        _this.contacts.push(new Contact(contact.editContact));
                        _this.$scope.newContact = null;
                    }
                    else {
                        _this.$scope.newContact = null;
                    }
                    contact.isEditing = !contact.isEditing;
                };
                this.toggleEditMode = function (contact, isDirty) {
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
                };
                this.getButtonText = function (contact, dirty, mode) {
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
                };
                this.contacts = [
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
                console.log("constructor");
            }
            return ListController;
        })();
        Controllers.ListController = ListController;
        angular.module("contactsApp").controller("listCtrl", Training.Controllers.ListController);
    })(Controllers = Training.Controllers || (Training.Controllers = {}));
})(Training || (Training = {}));
//# sourceMappingURL=list.controller.js.map