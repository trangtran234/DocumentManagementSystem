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
                var docsTreeCollapse = new Array<DocumentTree>();
                angular.forEach(scope.documentsTree, function (value, key) {
                    
                    if (value.id === document.id) {
                        if (document.childrens.length !== 0) {
                            angular.forEach(document.childrens, function (value, key) {
                                value.isExpanded = false;

                                var coll = "collapse-" + value.id;
                                var collapse = "#collapse-" + value.id;
                                var classCollapse = $(collapse).attr("class");
                                $("div[id*='" + coll + "']").removeClass(classCollapse).addClass('collapse');

                                if (value.childrens.length !== 0) {
                                    angular.forEach(value.childrens, function (value, key) {
                                        value.isExpanded = false;

                                        var classColl = "collapse-" + value.id;
                                        var childCollapse = "#collapse-" + value.id;
                                        var childClassCollapse = $(childCollapse).attr("class");;
                                        $("div[id*='" + classColl + "']").removeClass(childClassCollapse).addClass('collapse');
                                    })
                                }
                            })
                        }
                    }
                    else {
                        var parentDocTree = value;
                        var isFlag = true;
                        angular.forEach(value.childrens, function (value, key) {
                            if (value.id === document.id) {
                                isFlag = false;
                                if (document.childrens.length !== 0) {
                                    angular.forEach(document.childrens, function (value, key) {
                                        value.isExpanded = false;

                                        var coll = "collapse-" + value.id;
                                        var collapse = "#collapse-" + value.id;
                                        var classCollapse = $(collapse).attr("class");
                                        $("div[id*='" + coll + "']").removeClass(classCollapse).addClass('collapse');
                                    })
                                }
                            }
                        })
                        if (isFlag) {
                            docsTreeCollapse.push(parentDocTree);
                        }
                    }

                    angular.forEach(docsTreeCollapse, function (value, key) {
                        value.isExpanded = false;

                        var coll = "collapse-" + value.id;
                        var collapse = "#collapse-" + value.id;
                        var classCollapse = $(collapse).attr("class");
                        $("div[id*='" + coll + "']").removeClass(classCollapse).addClass('collapse');
                    })
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