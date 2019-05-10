var rootApp;
(function (rootApp) {
    var MainController = /** @class */ (function () {
        function MainController($scope) {
        }
        return MainController;
    }());
    rootApp.MainController = MainController;
    //angular.module('directiveModule', [])
    //    .directive('userLogin', UserLoginDirective.Factory())
    //    .directive('addDocument', AddDocumentDirective.Factory());
    //angular.module('controllerModule', ['directiveModule'])
    //    .controller('UserLoginController', UserLoginController)
    //      .controller('MainController', MainController);
    //angular.module('rootApp', ['controllerModule', 'directiveModule']);
    angular.module('rootApp', []).controller('MainController', MainController);
})(rootApp || (rootApp = {}));
//# sourceMappingURL=MainController.js.map