var rootApp;
(function (rootApp) {
    var MainController = /** @class */ (function () {
        function MainController($scope) {
            $scope.user = { userName: 'James' };
        }
        return MainController;
    }());
    rootApp.MainController = MainController;
    angular.module('rootApp', []).controller('MainController', MainController);
})(rootApp || (rootApp = {}));
//# sourceMappingURL=MainController.js.map