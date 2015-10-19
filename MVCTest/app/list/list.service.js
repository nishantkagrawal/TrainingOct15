var Training;
(function (Training) {
    var Services;
    (function (Services) {
        var TM = Training.Models;
        var ContactsService = (function () {
            function ContactsService($resource) {
                var _this = this;
                this.$resource = $resource;
                this.getAllContacts = function () {
                    var query = _this.resource.query();
                    var contacts = new Array();
                    query.$promise.then(function (results) {
                        //console.log(results);
                        for (var i = 0; i < results.length; i++) {
                            //console.log(results[i]);
                            contacts.push(new TM.Contact(results[i]));
                        }
                    });
                    return contacts;
                };
                this.getContact = function (contactId) {
                    return _this.resource.get(contactId);
                };
                this.saveContact = function (contactId, contact) {
                    return _this.resource.save({ id: contactId }, contact);
                };
                this.createContact = function (contact) {
                    return _this.resource.create(contact);
                };
                this.deleteContact = function (contact) {
                    console.log(contact.id);
                    return _this.resource.delete({ id: contact.id });
                };
                this.resource = $resource("api/Contacts/:id", { id: "@id" }, {
                    get: { method: "GET" },
                    save: { method: "PUT" },
                    query: { method: 'GET', isArray: true },
                    create: { method: 'POST' },
                    delete: { method: "Delete" }
                });
            }
            return ContactsService;
        })();
        Services.ContactsService = ContactsService;
        angular.module("contactsApp").service("contactsService", ContactsService);
    })(Services = Training.Services || (Training.Services = {}));
})(Training || (Training = {}));
//# sourceMappingURL=list.service.js.map