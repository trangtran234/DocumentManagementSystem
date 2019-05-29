module rootApp {
    'use strict';
    import Document = rootApp.model.Document;
    import DocumentType = rootApp.model.DocumentType;

    interface IEditScope extends ng.IScope {
        document: Document;
        saveDocument: () => void;
    }

    export class EditDocumentDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/editDocument.html';
        public scope = {
            documentTypes: '='
        }

        constructor(private $http: ng.IHttpService, private $rootScope: ng.IRootScopeService) {

        }

        public static Factory(): ng.IDirectiveFactory {
            const directive = ($http: ng.IHttpService, $rootScope: ng.IRootScopeService) => new EditDocumentDirective($http, $rootScope);
            directive.$inject = ['$http', '$rootScope'];
            return directive;
        }

        public link: ng.IDirectiveLinkFn = (
            scope: IEditScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes,
        ) => {
            var http = this.$http;
            var rootScope = this.$rootScope;

            //var parentID = null;
            //scope.$on('rootScope:id', function (event, data) {
            //    parentID = data;
            //});

            var listeningDocumentId = scope.$on('rootScope:edit', function (event, data) {
                http.get<Document>('/api/documents/DocumentById/' + data)
                    .then((response: ng.IHttpPromiseCallbackArg<Document>) => {
                        scope.document = response.data;
                    });
            });

            scope.$on('$destroy', function () {
                listeningDocumentId();
            });

            scope.saveDocument = () => {
                 http.post('/api/documents/UpdateDocument', scope.document)
                     .then(function (response) {
                         var parentID = null;
                         scope.$on('rootScope:id', function (event, data) {
                             parentID = data;
                         });
                         rootScope.$broadcast('rootScope:successEditDocument', parentID);
                         setTimeout(function () {
                            $('#edit').modal('hide');
                         }, 1000) 
                     })
                     ;
            }
        }
    }
}