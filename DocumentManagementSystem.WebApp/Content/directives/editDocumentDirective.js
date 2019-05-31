var rootApp;
(function (rootApp) {
    'use strict';
    var EditDocumentDirective = /** @class */ (function () {
        function EditDocumentDirective($http, $rootScope) {
            var _this = this;
            this.$http = $http;
            this.$rootScope = $rootScope;
            this.restrict = "E";
            this.templateUrl = '/Content/directives/editDocument.html';
            this.scope = {
                documentTypes: '='
            };
            this.link = function (scope, element, attributes) {
                var http = _this.$http;
                var rootScope = _this.$rootScope;
                var parentID = null;
                var listeningDocumentId = scope.$on('rootScope:edit', function (event, data) {
                    http.get('/api/documents/DocumentById/' + data)
                        .then(function (response) {
                        scope.document = response.data;
                    });
                    scope.$on('rootScope:parentId', function (event, data) {
                        parentID = data;
                    });
                });
                scope.$on('$destroy', function () {
                    listeningDocumentId();
                });
                scope.saveDocument = function () {
                    http.post('/api/documents/UpdateDocument', scope.document)
                        .then(function (response) {
                        rootScope.$broadcast('rootScope:successEditDocument', parentID);
                        setTimeout(function () {
                            $('#edit').modal('hide');
                        }, 1000);
                    });
                };
            };
        }
        EditDocumentDirective.Factory = function () {
            var directive = function ($http, $rootScope) { return new EditDocumentDirective($http, $rootScope); };
            directive.$inject = ['$http', '$rootScope'];
            return directive;
        };
        return EditDocumentDirective;
    }());
    rootApp.EditDocumentDirective = EditDocumentDirective;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=editDocumentDirective.js.map