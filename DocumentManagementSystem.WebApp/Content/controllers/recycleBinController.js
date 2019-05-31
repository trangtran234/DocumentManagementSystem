var rootApp;
(function (rootApp) {
    'user strict';
    var RecycleBinController = /** @class */ (function () {
        function RecycleBinController($http, $scope) {
            var _this = this;
            this.$http = $http;
            this.$scope = $scope;
            this.$http.get('/api/documenttypes/DocumentTypes')
                .then(function (response) {
                _this.$scope.documentTypes = response.data;
            });
        }
        RecycleBinController.$inject = ['$http', '$scope'];
        return RecycleBinController;
    }());
    rootApp.RecycleBinController = RecycleBinController;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=recycleBinController.js.map