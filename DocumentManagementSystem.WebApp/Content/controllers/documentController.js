var rootApp;
(function (rootApp) {
    'user strict';
    var DocumentController = /** @class */ (function () {
        function DocumentController($http, $scope) {
            this.$http = $http;
            this.$scope = $scope;
            this.onSave = function () {
                //reload the list
            };
            $scope.onSave = this.onSave;
            //$scope.uploadFiles = this.uploadFiles;
        }
        DocumentController.$inject = ['$http', '$scope'];
        return DocumentController;
    }());
    rootApp.DocumentController = DocumentController;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentController.js.map