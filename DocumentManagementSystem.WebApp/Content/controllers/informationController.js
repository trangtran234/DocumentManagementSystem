var rootApp;
(function (rootApp) {
    'user strict';
    var InformationController = /** @class */ (function () {
        function InformationController($scope) {
            this.$scope = $scope;
            $scope.$on('rootScope:documentInfo', function (event, data) {
                $scope.document = data;
            });
        }
        InformationController.$inject = ['$scope'];
        return InformationController;
    }());
    rootApp.InformationController = InformationController;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=informationController.js.map