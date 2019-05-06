//class Customer {
//    public name: string;
//    public address: string;
//    constructor(name: string, address: string) {
//        this.name = name;
//        this.address = address;
//    }
//}

//class SimpleController {
//    public customer = new Customer('Naomi', '1600 Amphitheatre');
//    constructor($scope) {
//        $scope.vm = this;
//    }
//}

//class SimpleDirective {
//    static MyCustomerDirective(): ng.IDirective {
//        return {
//            controller: SimpleController,
//            templateUrl: './templates/my-customer.html'
//        };
//    }
//}

//myApp.directive('myCustomer', function (): ng.IDirective {
//    return {
//        restrict: 'E',
//        template: 'Name: {{customer.name}} Address: {{customer.address}}'
//    }
//});

//class FooDirective implements ng.IDirective {
//    template = 'Name: {{customer.name}} Address: {{customer.address}}';
//    controller = SimpleController;
//}

module rootApp {
    var myApp = angular.module('rootApp', []);
}

//var myApp = angular.module('demoApp', []);
//myApp.controller('SimpleController', SimpleController.AngularDependencies);
//myApp.directive('myCustomer', SimpleDirective.MyCustomerDirective)

//myApp.directive('myCustomer', FooDirective);