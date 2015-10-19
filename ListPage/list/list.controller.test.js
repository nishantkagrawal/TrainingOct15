/// <reference path="../typings/angularjs/angular.d.ts" />
/// <reference path="../typings/angularjs/angular-mocks.d.ts" />
/// <reference path="../typings/jasmine/jasmine.d.ts" />
var Training;
(function (Training) {
    var Tests;
    (function (Tests) {
        describe("List Controller", function () {
            beforeEach(angular.mock.module("contactsApp"));
            var scope;
            var vm;
            beforeEach(inject(function ($controller) {
                scope = {};
                vm = $controller("listCtrl", { $scope: scope }); //this gets all the properties in the controller, really this is what vm is, right?
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
        });
    })(Tests = Training.Tests || (Training.Tests = {}));
})(Training || (Training = {}));
//# sourceMappingURL=list.controller.test.js.map