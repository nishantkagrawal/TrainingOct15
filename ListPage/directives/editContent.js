var EditContent = (function () {
    function EditContent() {
        var directive = {};
        directive.restrict = "EA";
        directive.templateUrl = "/list/editForm.html";
        //directive.replace = true;
        directive.scope = {
            contact: "=",
            mode: "=",
            getButtonText: "=",
            toggleEditMode: "=",
            activeEditing: "=",
            deleteContact: "="
        };
        console.log(directive.scope);
        return directive;
    }
    return EditContent;
})();
angular.module("contactsApp").directive("editContent", [EditContent]);
//# sourceMappingURL=editContent.js.map