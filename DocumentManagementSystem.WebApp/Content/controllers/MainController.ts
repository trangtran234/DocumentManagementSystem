module rootApp {
    export class MainController {
        constructor($scope) {
            $scope.user = { userName: 'James' };
        }
    }
    angular.module('rootApp', []).controller('MainController', MainController);
}