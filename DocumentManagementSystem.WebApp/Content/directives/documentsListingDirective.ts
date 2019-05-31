module rootApp {
    'use strict';

    import Document = rootApp.model.Document;

    export interface IMyDocumentScope extends ng.IScope {
        documents: Document[];
        getChildDocument: (id) => void;
        getChildDocumentOfFolder: (id) => void;
        getInfoOfDocument: (id) => void;
        editDocument: (id) => void;
        sort: (propertyName) => void;
        propertyName : any;
        reverse: any;

        currentPage: number;
        pageSize: number;
        numberOfPages: () => void;
        documentsLength: number;
    }

    export class DocumentsListingDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/documentsListing.html';
        public scope = {
            documentTypes: '='
        }

        constructor(private $http: ng.IHttpService,
            private $rootScope: ng.IRootScopeService,
            private orderBy: ng.IFilterOrderBy,
            private $filter: ng.FilterFactory,
            private $uibModal: ng.ui.bootstrap.IModalService) {

        }

        public static Factory(): ng.IDirectiveFactory {
            const directive = ($http: ng.IHttpService,
                $rootScope: ng.IRootScopeService,
                orderBy: ng.IFilterOrderBy,
                $filter: ng.FilterFactory,
                $uibModal: ng.ui.bootstrap.IModalService) => new DocumentsListingDirective($http, $rootScope, orderBy, $filter, $uibModal);

            directive.$inject = ['$http', '$rootScope', 'orderByFilter', '$filter', '$uibModal'];
            return directive;
        }

        public link: ng.IDirectiveLinkFn = (
            scope: IMyDocumentScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes,
        ) => {
            var http = this.$http;
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

            scope.editDocument = (id) => {

                var modalInstance = this.$uibModal.open({
                    animation: false,
                    scope: scope,
                    templateUrl: '/Content/directives/editDocument.html',
                    controller: 'ModalInstanceController',
                    resolve: {
                        id: function () {
                            return id;
                        },
                        parentId: function () {
                            return parentId;
                        }
                    }
                });
            };

            scope.$on('rootScope:successEditDocument', function (event, data) {
                scope.getChildDocument(data);
            });

            scope.getChildDocument = (id) => {
                http.get<Document[]>('/api/documents/DocumentByFolderId/' + id)
                    .then((response: ng.IHttpPromiseCallbackArg<Document[]>) => {
                        scope.documents = response.data;
                        scope.documentsLength = scope.documents.length;
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

            scope.sort = (propertyName) => {
                scope.reverse = (scope.propertyName === propertyName) ? !scope.reverse : false;
                scope.propertyName = propertyName;
                scope.documents = this.orderBy(scope.documents, scope.propertyName, scope.reverse);
            }

            scope.currentPage = 0;
            scope.pageSize = 5;

            scope.numberOfPages = () => {              
                return Math.ceil(scope.documentsLength / scope.pageSize);
            }

            this.$filter('limitTo')(scope.documents, scope.pageSize, function () {
                return function (input, start) {
                    start = +start;
                    return input.slice(start);
                }
            })

        }

        
    };
}