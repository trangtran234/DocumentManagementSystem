var rootApp;
(function (rootApp) {
    'user strict';
    ;
    var DocumentService = /** @class */ (function () {
        function DocumentService($http) {
            this.$http = $http;
        }
        DocumentService.prototype.uploadFile = function (document) {
            return this.$http.post('api/upload', document)
                .then(function (response) {
                return response.data;
            });
        };
        DocumentService.prototype.getDocumentIntoListView = function () {
            return this.$http.get('/api/documents/DocumentByFolderId/3');
        };
        DocumentService.$inject = ['$http'];
        return DocumentService;
    }());
    rootApp.DocumentService = DocumentService;
    factory.$inject = ['$http'];
    function factory($http) {
        return new DocumentService($http);
    }
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentService.js.map