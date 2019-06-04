module rootApp {
    'use strict';

    import Document = rootApp.model.Document;

    export interface IMyDocumentScope extends ng.IScope {
        documents: Document[];
        getChildDocument: (id, currentPage, propertyName) => void;
        //getChildDocumentOfFolder: (id) => void;
        getDocumentsByTreeView: (document: Document) => void;
        getInfoOfDocument: (id) => void;
        editDocument: (id) => void;
        sort: (propertyName) => void;
        propertyName : any;
        reverse: any;

        currentPage: number;
        pageSize: number;
        numberOfPages: () => void;
        documentsLength: number;
        init: () => void;
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
            //$('#listingTable > tbody > tr').click(function () {
            //    $(this).addClass('bg-success').siblings().removeClass('bg-success');
            //});

            var http = this.$http;
            var rootScope = this.$rootScope;
            var parentId = 0;
            var created = 'created';
            scope.currentPage = 0;
            scope.pageSize = 5;

            scope.$on('rootScope:id', function (event, data) {
                parentId = data;
                scope.init();
                scope.getChildDocument(parentId, scope.currentPage, created);
            });

            //scope.$on('rootScope:treeviewId', function (event, data) {
            //    scope.getChildDocument(data, scope.currentPage);
            //});
            
            scope.$on('uploadSuccess', function (event, data) {
                scope.init();
                scope.getChildDocument(data, scope.currentPage, created);
                rootScope.$broadcast('history:sucessed', 'sucessed');
            });

            scope.editDocument = (id) => {

                var modalInstance = this.$uibModal.open({
                    animation: false,
                    scope: scope,
                    templateUrl: '/Content/directives/editDocument.html',
                    controller: 'ModalInstanceController',
                    size: 'lg',
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
                scope.getChildDocument(data, scope.currentPage, created);
                rootScope.$broadcast('history:sucessed', 'sucessed');
            });

            //scope.getChildDocumentOfFolder = (id) => {
            //    scope.init();
            //    scope.getChildDocument(id, scope.currentPage, documentName);
            //    this.$http.get<Document>('/api/documents/DocumentById/' + id)
            //        .then((response: ng.IHttpPromiseCallbackArg<Document>) => {
            //            var document = response.data;
            //            this.$rootScope.$broadcast('rootScope:documentInfo', document)
            //            var isVisible = true;
            //            this.$rootScope.$broadcast('rootScope:isVisible', isVisible);
            //        });
            //}

            scope.getDocumentsByTreeView = (document) => {
                if (document.documentType !== 'folder') {
                    scope.getInfoOfDocument(document.id);
                }
                else {
                    scope.init();
                    scope.getChildDocument(document.id, scope.currentPage, created);
                    scope.getInfoOfDocument(document.id);
                }
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
                scope.init();
                scope.reverse = (scope.propertyName === propertyName) ? !scope.reverse : false;
                scope.propertyName = propertyName;               
                scope.getChildDocument(parentId, scope.currentPage, propertyName);
            }
            
            scope.getChildDocument = (id, currentPage, propertyName) => {

                if (typeof id === 'undefined') {
                    id = parentId;
                }

                if (typeof propertyName === 'undefined') {
                    propertyName = created;
                }

                if (typeof scope.reverse === 'undefined') {
                    scope.reverse = true;
                }

                http({
                    url: '/api/documents/LazyLoadDocuments?page=' + currentPage + '&pageSize=' + scope.pageSize + '&parentId=' + id + '&desc=' + scope.reverse + '&propertyName=' + propertyName,
                    method: "GET",
                }).then(function success(response) {

                    var obj = angular.fromJson(response.data as string);

                    scope.documentsLength = obj.totalRecords;
                    scope.documents = [];

                    angular.forEach(obj.documents, function (value, key) {
                        var dt: Document = {};

                        dt.id = value.id;
                        dt.documentName = value.documentName;
                        dt.documentType = value.documentType;
                        dt.documentTypes = value.documentTypes;

                        dt.createdBy = value.createdBy;
                        dt.lastModifiedBy = value.lastModifiedBy;
                        dt.created = value.created;
                        dt.lastModified = value.lastModified;

                        scope.documents.push(dt);
                    });

                    scope.$apply;     
                    
                    }, function error(response) {
                        console.log('error: ' + response)
                    });
            }

            scope.numberOfPages = () => {
                var totalPages = Math.ceil(scope.documentsLength / scope.pageSize);
                if (totalPages === 0 || isNaN(totalPages))
                {
                    totalPages = 1;
                }
                return totalPages;
            }

            scope.init = () => {
                scope.currentPage = 0;
                scope.documents = [];
            }

            scope.getChildDocument(0, scope.currentPage, scope.propertyName);
        }        
    };
}