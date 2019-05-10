module rootApp {
    export class UserLoginController {
        constructor($scope) {
            $scope.user = { userName: 'James' };
        }
    }

    export class UserLoginDirective implements ng.IDirective {
        public restrict: string = 'E'
        public templateUrl: string = '/Content/directives/user-login.html';

        public static Factory(): ng.IDirectiveFactory {
            return () => new UserLoginDirective();
        }
    }

    //angular.module('directiveModule', [])
    //    .directive('userLogin', UserLoginDirective.Factory())
    //    .directive('addDocument', AddDocumentDirective.Factory());

    //angular.module('controllerModule', ['directiveModule'])
    //    .controller('UserLoginController', UserLoginController);

    //angular.module('rootApp', ['controllerModule', 'directiveModule']);

    //angular.module('rootApp', [])
    //    .controller('UserLoginController', UserLoginController)
    //    .directive('userLogin', UserLoginDirective.Factory());
}