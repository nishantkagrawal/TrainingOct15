class EditContent {
    constructor() {
        var directive: ng.IDirective = {};
        directive.restrict = "EA";
        directive.templateUrl = "/app/list/editForm.html";
        //directive.replace = true;
        directive.scope = {
            contact: "=",
            mode: "=",
            getButtonText: "=",
            toggleEditMode: "=",
            activeEditing: "=",
            deleteContact: "="
        };

        //console.log(directive.scope);

        return directive;
    }
}
angular.module("contactsApp").directive("editContent", [EditContent]);