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

        treeId: number;
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

            scope.onAddedNewFiles = () => {
                scope.getChildDocumentIntoListing(3);
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