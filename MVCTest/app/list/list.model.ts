namespace Training.Models {
    export interface IContactBase {
        id?: number;
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

    export interface IContact extends ng.resource.IResource<IContactBase> {
    }

    export class Contact implements IContactBase {
        public id: number;
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
        public editContact: IContactBase;

        constructor(contact: IContactBase) {
            if (contact == null) {
                contact = {};
            }
            this.assignProperties(contact, this);
            this.isEditing = false;
            this.showDetails = false;
        }

        public createNewIContact = (): IContactBase => {
            var tempIContact: IContactBase =
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
            return this.isEditing;
        }

        public toggleShowDetails = () => {
            //console.log("show details");
            this.showDetails = !this.showDetails;
        }

        public assignProperties = (source: IContactBase, dest: IContactBase) => {
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
        }
    }
}