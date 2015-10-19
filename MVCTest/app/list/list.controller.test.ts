
namespace Training.Tests {    
    import TC = Training.Controllers;
    import TS = Training.Services;
    describe("List Controller", () => {
        var vm: TC.ListController;

        beforeEach(angular.mock.module("contactsApp"));

        beforeEach(() => {
            angular.mock.module(($provide: ng.auto.IProvideService) => {
                $provide.service("contactsService", TS.Mock.ContactsMockService);
            });
           
        });

        beforeEach(inject(($controller: ng.IControllerService, $injector: ng.auto.IInjectorService) => {
            var scope = {};
            var contactsService = $injector.get("contactsService");
            vm = $controller<TC.ListController>("listCtrl", { $scope: scope, contactsService: contactsService }); //this gets all the properties in the controller, really this is what vm is, right?
        }));

        it("should be defined", () => {
            expect(vm).toBeDefined();
        });

        it("should have contacts defined", () => {
            expect(vm.contacts).toBeDefined();
        });

        it("should have some contacts (len > 0)", () => {
            expect(vm.contacts.length).toBeGreaterThan(0);
        });

        it("default should be last name", () => {
            expect(vm.sortOrder).toBe("lastName");
        });

        //it("should fail : default should be null", () => {
        //    expect(vm.sortOrder).toBe(undefined);
        //});

        //you can also invoke functions on a controller from unit tests
        
        it("is just a test to see that function can be invoked", () => {
            //initially the value of forUnitTest is false
            expect(vm.forUnitTest).toBe(false);
            vm.testFunction(true);
            expect(vm.forUnitTest).toBe(true);
        });

        describe("delete button", () => {
            var window: ng.IWindowService;
            beforeEach(inject(($window) => {
                window = $window;
            }));

            it("delete removes a contact", () => {
                window.confirm = () => {
                    return true;
                }
                var length = vm.contacts.length;
                var contactToDelete = vm.contacts[length - 2];
                vm.deleteContact(contactToDelete);
                expect(vm.contacts.length).toBe(length - 1);
                expect(vm.contacts.indexOf(contactToDelete)).toBe(-1);
            });

            it("delete and cancel does nothing contact", () => {
                window.confirm = () => {
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
}

