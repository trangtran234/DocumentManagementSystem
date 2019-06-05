module rootApp {
    'use strict';

    import DocumentTree = rootApp.model.DocumentTree;

    interface IMyDocumentScope extends ng.IScope {
        documentsTree: DocumentTree[];
        getChildFolderOfTree: (id) => void;
        childDocuments: DocumentTree[];
        onAddedNewFiles: () => void;
        getChildDocumentIntoListing: (id) => void;
        toggleButton: (document: DocumentTree) => void;
        resetExpanded: (document: DocumentTree) => void;
    }

    export class DocumentTreeViewDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/documentTreeView.html';

        constructor(private $http: ng.IHttpService, private $rootScope: ng.IRootScopeService) { }

        public static Factory() {
            const directive = ($http: ng.IHttpService, $rootScope: ng.IRootScopeService) => new DocumentTreeViewDirective($http, $rootScope);
            directive.$inject = ['$http', '$rootScope'];
            return directive;
        }

        public link: ng.IDirectiveLinkFn = (
            scope: IMyDocumentScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes,
        ) => {
            this.$http.get<DocumentTree[]>('/api/documents/FolderStructure')
                .then((response: ng.IHttpPromiseCallbackArg<DocumentTree[]>) => {
                    scope.documentsTree = response.data;
                });

            scope.getChildDocumentIntoListing = (id) => {
                this.$rootScope.$broadcast('rootScope:id', id);
            }

            scope.$on('listing:document', function (event, data) {
                var treeView = new DocumentTree();
                var docTree = new DocumentTree();
                angular.forEach(scope.documentsTree, function (value, key) {
                    if (value.id === data.parentId) {
                        treeView = value;
                        angular.forEach(treeView.childrens, function (value, key) {
                            if (value.id === data.id) {
                                docTree = value;
                            }
                        })
                    }
                    else {
                        angular.forEach(value.childrens, function (value, key) {
                            if (value.id === data.parentId) {
                                treeView = value;
                                angular.forEach(treeView.childrens, function (value, key) {
                                    if (value.id === data.id) {
                                        docTree = value;
                                    }
                                })
                            }
                        })
                    }
                })
                scope.toggleButton(docTree);
            });

            scope.resetExpanded = (document) => {
                angular.forEach(scope.documentsTree, function (value, key) {
                    if (value.id === document.id) {
                        if (document.childrens.length !== 0) {
                            angular.forEach(document.childrens, function (value, key) {
                                value.isExpanded = false;
                                if (value.childrens.length !== 0) {
                                    angular.forEach(value.childrens, function (value, key) {
                                        value.isExpanded = false;
                                    })
                                }
                            })
                        }
                    }
                    else {
                        angular.forEach(value.childrens, function (value, key) {
                            if (value.id === document.id) {
                                if (document.childrens.length !== 0) {
                                    angular.forEach(document.childrens, function (value, key) {
                                        value.isExpanded = false;
                                    })
                                }
                            }
                        })
                    }
                })
            }

            scope.toggleButton = (document: DocumentTree) => {
                if (document.isExpanded === true) {
                    document.isExpanded = false;
                }
                else {
                    document.isExpanded = true;
                }
            }
        };
    }
}