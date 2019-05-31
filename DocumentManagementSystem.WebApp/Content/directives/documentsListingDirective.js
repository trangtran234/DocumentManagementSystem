var rootApp;
(function (rootApp) {
    'use strict';
    var DocumentsListingDirective = /** @class */ (function () {
        //public scope = {
        //    documents: '='
        //}
        function DocumentsListingDirective($http, $rootScope, orderBy, $filter) {
            var _this = this;
            this.$http = $http;
            this.$rootScope = $rootScope;
            this.orderBy = orderBy;
            this.$filter = $filter;
            this.restrict = "E";
            this.templateUrl = '/Content/directives/documentsListing.html';
            this.link = function (scope, element, attributes) {
                var http = _this.$http;
                var parentId = null;
                scope.$on('rootScope:id', function (event, data) {
                    scope.documents = [];
                    parentId = data;
                    scope.getChildDocument(parentId);
                });
                scope.$on('rootScope:treeviewId', function (event, data) {
                    scope.getChildDocument(data);
                });
                scope.$on('uploadSuccess', function (event, data) {
                    scope.getChildDocument(data);
                });
                scope.editDocument = function (id) {
                    _this.$rootScope.$broadcast('rootScope:edit', id);
                    _this.$rootScope.$broadcast('rootScope:parentId', parentId);
                };
                scope.$on('rootScope:successEditDocument', function (event, data) {
                    scope.getChildDocument(data);
                });
                scope.getChildDocument = function (id) {
                    http.get('/api/documents/DocumentByFolderId/' + id)
                        .then(function (response) {
                        scope.documents = response.data;
                        scope.documentsLength = scope.documents.length;
                    });
                };
                scope.getChildDocumentOfFolder = function (id) {
                    scope.getChildDocument(id);
                    _this.$http.get('/api/documents/DocumentById/' + id)
                        .then(function (response) {
                        var document = response.data;
                        _this.$rootScope.$broadcast('rootScope:documentInfo', document);
                        var isVisible = true;
                        _this.$rootScope.$broadcast('rootScope:isVisible', isVisible);
                    });
                };
                scope.getInfoOfDocument = function (id) {
                    _this.$http.get('/api/documents/DocumentById/' + id)
                        .then(function (response) {
                        var document = response.data;
                        _this.$rootScope.$broadcast('rootScope:documentInfo', document);
                        var isVisible = true;
                        _this.$rootScope.$broadcast('rootScope:isVisible', isVisible);
                    });
                };
                scope.sort = function (propertyName) {
                    scope.reverse = (scope.propertyName === propertyName) ? !scope.reverse : false;
                    scope.propertyName = propertyName;
                    scope.documents = _this.orderBy(scope.documents, scope.propertyName, scope.reverse);
                };
                scope.currentPage = 0;
                scope.pageSize = 5;
                scope.numberOfPages = function () {
                    return Math.ceil(scope.documentsLength / scope.pageSize);
                };
                _this.$filter('limitTo')(scope.documents, scope.pageSize, function () {
                    return function (input, start) {
                        start = +start;
                        return input.slice(start);
                    };
                });
            };
        }
        DocumentsListingDirective.Factory = function () {
            var directive = function ($http, $rootScope, orderBy, $filter) { return new DocumentsListingDirective($http, $rootScope, orderBy, $filter); };
            directive.$inject = ['$http', '$rootScope', 'orderByFilter', '$filter'];
            return directive;
        };
        return DocumentsListingDirective;
    }());
    rootApp.DocumentsListingDirective = DocumentsListingDirective;
    ;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentsListingDirective.js.map