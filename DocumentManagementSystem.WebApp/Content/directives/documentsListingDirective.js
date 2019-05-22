var rootApp;
(function (rootApp) {
    'use strict';
    var DocumentsListingDirective = /** @class */ (function () {
        //public scope = {
        //    documents: '='
        //}
        function DocumentsListingDirective($http, $rootScope) {
            var _this = this;
            this.$http = $http;
            this.$rootScope = $rootScope;
            this.restrict = "E";
            this.templateUrl = '/Content/directives/documentsListing.html';
            this.link = function (scope, element, attributes) {
                var http = _this.$http;
                scope.$on('rootScope:id', function (event, data) {
                    http.get('/api/documents/DocumentByFolderId/' + data)
                        .then(function (response) {
                        scope.documents = response.data;
                    });
                });
                scope.getChildDocumentOfFolder = function (id) {
                    _this.$http.get('/api/documents/DocumentByFolderId/' + id)
                        .then(function (response) {
                        scope.documents = response.data;
                    });
                    _this.$http.get('/api/documents/DocumentById/' + id)
                        .then(function (response) {
                        var document = response.data;
                        _this.$rootScope.$broadcast('rootScope:documentInfo', document);
                    });
                };
                scope.getInfoOfDocument = function (id) {
                    _this.$http.get('/api/documents/DocumentById/' + id)
                        .then(function (response) {
                        var document = response.data;
                        _this.$rootScope.$broadcast('rootScope:documentInfo', document);
                    });
                };
            };
        }
        DocumentsListingDirective.Factory = function () {
            var directive = function ($http, $rootScope) { return new DocumentsListingDirective($http, $rootScope); };
            directive.$inject = ['$http', '$rootScope'];
            return directive;
        };
        return DocumentsListingDirective;
    }());
    rootApp.DocumentsListingDirective = DocumentsListingDirective;
    ;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentsListingDirective.js.map