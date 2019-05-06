module rootApp {
    class UserLoginDirective {
        static UserLoginDirective(): ng.IDirective {
            return {
                controller: MainController,
                template: 'Name: {{user.userName}}'
            };
        }
    }
    angular.module('rootApp', []).directive('userLogin', UserLoginDirective.UserLoginDirective);
}