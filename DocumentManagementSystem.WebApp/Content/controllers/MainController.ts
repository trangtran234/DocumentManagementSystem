module rootApp {
    export class MainController {
        constructor($scope) {
        }
    }
    //angular.module('directiveModule', [])
    //    .directive('userLogin', UserLoginDirective.Factory())
    //    .directive('addDocument', AddDocumentDirective.Factory());

    //angular.module('controllerModule', ['directiveModule'])
    //    .controller('UserLoginController', UserLoginController)
    //      .controller('MainController', MainController);

    //angular.module('rootApp', ['controllerModule', 'directiveModule']);

    angular.module('rootApp', []).controller('MainController', MainController);
}