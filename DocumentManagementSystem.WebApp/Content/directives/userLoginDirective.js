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
            templateUrl: '/Content/directives/user-login.html'
            //scope: { user: "=user"},
        };
    }
    angular.module('directiveModule', [])
        .directive('userLogin', UserLoginDirective)
        .directive('addDocument', rootApp.AddDocumentDirective.Factory());
    angular.module('controllerModule', ['directiveModule'])
        .controller('UserLoginController', UserLoginController);
    angular.module('rootApp', ['controllerModule', 'directiveModule']);
})(rootApp || (rootApp = {}));
//# sourceMappingURL=userLoginDirective.js.map