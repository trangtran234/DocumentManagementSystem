var rootApp;
(function (rootApp) {
    var UserLoginController = /** @class */ (function () {
        function UserLoginController($scope) {
            $scope.user = { userName: 'James' };
        }
        return UserLoginController;
    }());
    function UserLoginDirective() {
        return {
            templateUrl: '/Content/directives/user-login.html',
            scope: { user: "=user" },
        };
    }
    angular.module('rootApp', []).controller('UserLoginController', UserLoginController).directive('userLogin', UserLoginDirective);
})(rootApp || (rootApp = {}));
//# sourceMappingURL=userLoginDirective.js.map