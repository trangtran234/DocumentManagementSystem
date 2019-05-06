var rootApp;
(function (rootApp) {
    var UserLoginDirective = /** @class */ (function () {
        function UserLoginDirective() {
        }
        UserLoginDirective.UserLoginDirective = function () {
            return {
                controller: rootApp.MainController,
                template: 'Name: {{user.userName}}'
            };
        };
        return UserLoginDirective;
    }());
    angular.module('rootApp', []).directive('userLogin', UserLoginDirective.UserLoginDirective);
})(rootApp || (rootApp = {}));
//# sourceMappingURL=userLoginDirective.js.map