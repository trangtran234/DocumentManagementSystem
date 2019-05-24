module rootApp {
    'use strict';

    import Document = rootApp.model.Document;

    export interface IMyDocumentScope extends ng.IScope {
        documents: Document[];
        getChildDocument: (id) => void;
        getChildDocumentOfFolder: (id) => void;
        getInfoOfDocument: (id) => void;
    }

    export class DocumentsListingDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/documentsListing.html';
        //public scope = {
        //    documents: '='
        //}

        constructor(private $http: ng.IHttpService, private $rootScope: ng.IRootScopeService) {

        }

        public static Factory(): ng.IDirectiveFactory {
            const directive = ($http: ng.IHttpService, $rootScope: ng.IRootScopeService) => new DocumentsListingDirective($http, $rootScope);
            directive.$inject = ['$http', '$rootScope'];
            return directive;
        }

        public link: ng.IDirectiveLinkFn = (
            scope: IMyDocumentScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes,
        ) => {
            var http = this.$http;
            scope.$on('rootScope:id', function (event, data) {
                scope.getChildDocument(data);
            });

            scope.$on('uploadSuccess', function (event, data) {
                scope.getChildDocument(data);
            });

            scope.getChildDocument = (id) => {
                http.get<Document[]>('/api/documents/DocumentByFolderId/' + id)
                    .then((response: ng.IHttpPromiseCallbackArg<Document[]>) => {
                        scope.documents = response.data;
                    });
            }

            scope.getChildDocumentOfFolder = (id) => {
                scope.getChildDocument(id);
                this.$http.get<Document>('/api/documents/DocumentById/' + id)
                    .then((response: ng.IHttpPromiseCallbackArg<Document>) => {
                        var document = response.data;
                        this.$rootScope.$broadcast('rootScope:documentInfo', document)
                        var isVisible = true;
                        this.$rootScope.$broadcast('rootScope:isVisible', isVisible);
                    });
            }

            scope.getInfoOfDocument = (id) => {
                this.$http.get<Document>('/api/documents/DocumentById/' + id)
                    .then((response: ng.IHttpPromiseCallbackArg<Document>) => {
                        var document = response.data;
                        this.$rootScope.$broadcast('rootScope:documentInfo', document)
                        var isVisible = true;
                        this.$rootScope.$broadcast('rootScope:isVisible', isVisible);
                    });
            }
        }
    };
}