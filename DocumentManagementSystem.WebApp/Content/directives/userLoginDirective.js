var rootApp;
(function (rootApp) {
    var UserLoginController = /** @class */ (function () {
        function UserLoginController($scope) {
            $scope.user = { userName: 'James' };
        }
        return UserLoginController;
    }());
    rootApp.UserLoginController = UserLoginController;
    var UserLoginDirective = /** @class */ (function () {
        function UserLoginDirective() {
            this.restrict = 'E';
            this.templateUrl = '/Content/directives/user-login.html';
        }
        UserLoginDirective.Factory = function () {
            return function () { return new UserLoginDirective(); };
        };
        return UserLoginDirective;
    }());
    rootApp.UserLoginDirective = UserLoginDirective;
    //angular.module('directiveModule', [])
    //    .directive('userLogin', UserLoginDirective.Factory())
    //    .directive('addDocument', AddDocumentDirective.Factory());
    //angular.module('controllerModule', ['directiveModule'])
    //    .controller('UserLoginController', UserLoginController);
    //angular.module('rootApp', ['controllerModule', 'directiveModule']);
    //angular.module('rootApp', [])
    //    .controller('UserLoginController', UserLoginController)
    //    .directive('userLogin', UserLoginDirective.Factory());
})(rootApp || (rootApp = {}));
//# sourceMappingURL=userLoginDirective.js.map