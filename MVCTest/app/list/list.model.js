var Training;
(function (Training) {
    var Models;
    (function (Models) {
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
                    return _this.isEditing;
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
                    //console.log("source");
                    //console.log(source);
                    //console.log("destination");
                    //console.log(dest);
                    for (var prop in source) {
                        if (source.hasOwnProperty(prop)) {
                            dest[prop] = source[prop];
                        }
                    }
                    //dest.firstName = source.firstName;
                    //dest.lastName = source.lastName;
                    //dest.address = source.address;
                    //dest.city = source.city;
                    //dest.state = source.state;
                    //dest.zip = source.zip;
                    //dest.homePhone = source.homePhone;
                    //dest.cellPhone = source.cellPhone;
                    //dest.workPhone = source.workPhone;
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
        Models.Contact = Contact;
    })(Models = Training.Models || (Training.Models = {}));
})(Training || (Training = {}));
//# sourceMappingURL=list.model.js.map