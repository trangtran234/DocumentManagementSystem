module rootApp {

    class UserLoginController {
        constructor($scope) {
            $scope.user = { userName: 'James' };
        }
    }

    function UserLoginDirective(): ng.IDirective {
        return {
            templateUrl: '/Content/directives/user-login.html'
            //scope: { user: "=user"},
        };
    }

    angular.module('directiveModule', [])
        .directive('userLogin', UserLoginDirective)
        .directive('addDocument', AddDocumentDirective.Factory());

    angular.module('controllerModule', ['directiveModule'])
        .controller('UserLoginController', UserLoginController);

    angular.module('rootApp', ['controllerModule', 'directiveModule']);
}