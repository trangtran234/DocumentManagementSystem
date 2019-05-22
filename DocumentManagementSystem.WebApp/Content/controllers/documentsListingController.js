var rootApp;
(function (rootApp) {
    'user strict';
    var DocumentsListingController = /** @class */ (function () {
        function DocumentsListingController($http, $scope, $rootScope) {
            var _this = this;
            this.$http = $http;
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.getDocumentIntoListView = function () {
                _this.$http.get('/api/documents/DocumentByFolderId/3')
                    .then(function (response) {
                    _this.$scope.documents = response.data;
                });
            };
            this.getChildDocumentOfFolder = function (id) {
                _this.$http.get('/api/documents/DocumentByFolderId/' + id)
                    .then(function (response) {
                    _this.$scope.documents = response.data;
                });
                _this.$http.get('/api/documents/DocumentById/' + id)
                    .then(function (response) {
                    var document = response.data;
                    _this.$rootScope.$broadcast('rootScope:documentInfo', document);
                });
            };
            this.getInfoOfDocument = function (id) {
                _this.$http.get('/api/documents/DocumentById/' + id)
                    .then(function (response) {
                    _this.$rootScope.$broadcast('rootScope:documentInfo', response.data);
                });
            };
            this.getDocumentIntoListView();
            $scope.getChildDocumentOfFolder = this.getChildDocumentOfFolder;
            $scope.getInfoOfDocument = this.getInfoOfDocument;
        }
        DocumentsListingController.$inject = ['$http', '$scope', '$rootScope'];
        return DocumentsListingController;
    }());
    rootApp.DocumentsListingController = DocumentsListingController;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentsListingController.js.map