var Training;
(function (Training) {
    var Controllers;
    (function (Controllers) {
        var TM = Training.Models;
        var ListController = (function () {
            function ListController($scope, $window, contactsService) {
                var _this = this;
                this.$scope = $scope;
                this.$window = $window;
                this.contactsService = contactsService;
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
                    if (_this.$window.confirm("Are you sure you want to delete?")) {
                        _this.contactsService.deleteContact(contact);
                        var index = _this.contacts.indexOf(contact);
                        _this.contacts.splice(index, 1);
                    }
                };
                this.toggleAddMode = function (contact, isDirty) {
                    if (!contact) {
                        contact = new TM.Contact(null);
                        _this.$scope.newContact = contact;
                    }
                    else if (isDirty) {
                        var contactToSave = new TM.Contact(contact.editContact);
                        _this.contacts.push(contactToSave);
                        _this.contactsService.createContact(contactToSave);
                        _this.$scope.newContact = null;
                    }
                    else {
                        _this.$scope.newContact = null;
                    }
                    contact.isEditing = !contact.isEditing;
                };
                this.toggleEditMode = function (contact, isDirty) {
                    if (contact.isEditing == false) {
                        //this.editContact = <IContact>this;
                        if (contact.editContact == null) {
                            contact.editContact = contact.createNewIContact();
                        }
                        contact.assignProperties(contact, contact.editContact);
                        contact.isEditing = true;
                    }
                    else {
                        if (isDirty) {
                            contact.assignProperties(contact.editContact, contact);
                            contact.editContact = null;
                            _this.contactsService.saveContact(contact.id, contact);
                        }
                        else {
                        }
                        contact.isEditing = false;
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
                //this.contacts = contactsService.getAllContacts();
                this.contacts = contactsService.getAllContacts();
                //console.log(this.contacts);
            }
            return ListController;
        })();
        Controllers.ListController = ListController;
        angular.module("contactsApp").controller("listCtrl", Training.Controllers.ListController);
    })(Controllers = Training.Controllers || (Training.Controllers = {}));
})(Training || (Training = {}));
//# sourceMappingURL=list.controller.js.map