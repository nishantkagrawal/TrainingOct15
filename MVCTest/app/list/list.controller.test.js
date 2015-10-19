var Training;
(function (Training) {
    var Tests;
    (function (Tests) {
        var TS = Training.Services;
        describe("List Controller", function () {
            var vm;
            beforeEach(angular.mock.module("contactsApp"));
            beforeEach(function () {
                angular.mock.module(function ($provide) {
                    $provide.service("contactsService", TS.Mock.ContactsMockService);
                });
            });
            beforeEach(inject(function ($controller, $injector) {
                var scope = {};
                var contactsService = $injector.get("contactsService");
                vm = $controller("listCtrl", { $scope: scope, contactsService: contactsService }); //this gets all the properties in the controller, really this is what vm is, right?
            }));
            it("should be defined", function () {
                expect(vm).toBeDefined();
            });
            it("should have contacts defined", function () {
                expect(vm.contacts).toBeDefined();
            });
            it("should have some contacts (len > 0)", function () {
                expect(vm.contacts.length).toBeGreaterThan(0);
            });
            it("default should be last name", function () {
                expect(vm.sortOrder).toBe("lastName");
            });
            //it("should fail : default should be null", () => {
            //    expect(vm.sortOrder).toBe(undefined);
            //});
            //you can also invoke functions on a controller from unit tests
            it("is just a test to see that function can be invoked", function () {
                //initially the value of forUnitTest is false
                expect(vm.forUnitTest).toBe(false);
                vm.testFunction(true);
                expect(vm.forUnitTest).toBe(true);
            });
            describe("delete button", function () {
                var window;
                beforeEach(inject(function ($window) {
                    window = $window;
                }));
                it("delete removes a contact", function () {
                    window.confirm = function () {
                        return true;
                    };
                    var length = vm.contacts.length;
                    var contactToDelete = vm.contacts[length - 2];
                    vm.deleteContact(contactToDelete);
                    expect(vm.contacts.length).toBe(length - 1);
                    expect(vm.contacts.indexOf(contactToDelete)).toBe(-1);
                });
                it("delete and cancel does nothing contact", function () {
                    window.confirm = function () {
                        return false;
                    };
                    var length = vm.contacts.length;
                    var contactToDelete = vm.contacts[length - 2];
                    vm.deleteContact(contactToDelete);
                    expect(vm.contacts.length).toBe(length);
                    expect(vm.contacts.indexOf(contactToDelete)).toBe(length - 2);
                });
            });
        });
    })(Tests = Training.Tests || (Training.Tests = {}));
})(Training || (Training = {}));
//# sourceMappingURL=list.controller.test.js.map