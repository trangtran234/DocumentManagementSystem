var rootApp;
(function (rootApp) {
    'use strict';
    var documentTreeViewDirective = /** @class */ (function () {
        function documentTreeViewDirective($http, $rootScope) {
            var _this = this;
            this.$http = $http;
            this.$rootScope = $rootScope;
            this.restrict = "E";
            this.templateUrl = '/Content/directives/documentTreeView.html';
            this.link = function (scope, element, attributes) {
                _this.$http.get('/api/documents/FolderStructure')
                    .then(function (response) {
                    scope.documentsTree = response.data;
                });
                scope.getChildDocumentIntoListing = function (id) {
                    _this.$rootScope.$broadcast('rootScope:id', id);
                };
                scope.onAddedNewFiles = function () {
                    scope.getChildDocumentIntoListing(3);
                };
                scope.toggleButton = function (document) {
                    if (document.isExpanded === true) {
                        document.isExpanded = false;
                    }
                    else {
                        document.isExpanded = true;
                    }
                };
            };
        }
        documentTreeViewDirective.Factory = function () {
            var directive = function ($http, $rootScope) { return new documentTreeViewDirective($http, $rootScope); };
            directive.$inject = ['$http', '$rootScope'];
            return directive;
        };
        return documentTreeViewDirective;
    }());
    rootApp.documentTreeViewDirective = documentTreeViewDirective;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentTreeViewDirective.js.map