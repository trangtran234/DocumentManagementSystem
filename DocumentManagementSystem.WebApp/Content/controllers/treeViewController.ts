module rootApp {
    'user strict';

    import DocumentTree = rootApp.model.DocumentTree;

    interface IMyDocumentScope extends ng.IScope {
        documents: DocumentTree[];
        getChildFolderOfTree: (id) => void;
        childDocuments: DocumentTree[];
        onAddedNewFiles: () => void;
    }

    export class TreeViewController {
        static $inject = ['$scope', '$http'];
        constructor(private $scope: IMyDocumentScope, private $http: ng.IHttpService) {
            this.getFolders();
            $scope.getChildFolderOfTree = this.getChildFolderOfTree;
            $scope.onAddedNewFiles = () => {
                this.getChildFolderOfTree(3);
            };
        }

        getFolders = () => {
            this.$http.get<DocumentTree[]>('http://localhost:55865/api/documents/Folders')
                .then((response: ng.IHttpPromiseCallbackArg<DocumentTree[]>) => {
                    this.$scope.documents = response.data;
                });
        }

        getChildFolderOfTree = (id) => {
            this.$http.get<DocumentTree[]>('/api/documents/FolderByFolderId/' + id)
                .then((response: ng.IHttpPromiseCallbackArg<DocumentTree[]>) => {
                    this.$scope.childDocuments = response.data;
                });
        }
    }
}