module rootApp {
    class UserLoginController {
        constructor($scope) {
            $scope.user = { userName: 'James' };
        }
    }

    function UserLoginDirective(): ng.IDirective {
        return {
            templateUrl: '/Content/directives/user-login.html',
            scope: { user: "=user"},
        };
    }
    angular.module('rootApp', []).controller('UserLoginController', UserLoginController).directive('userLogin', UserLoginDirective)
}