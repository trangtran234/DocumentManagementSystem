module rootApp {
    'user strict';

    import Document = rootApp.model.Document;

    interface IDocumentScope extends ng.IScope {
        documents: Document[];
        getDocumentByFolderId: (id) => void;
    }

    export class TableController  {
        static $inject = ['$http', '$scope'];

        constructor(private $http: ng.IHttpService, private $scope: IDocumentScope, ) {
            this.getDocument()
                .then((response: ng.IHttpPromiseCallbackArg<Document[]>): Document[] => {
                    return <Document[]>response.data;
                })
                .then((response: Document[]) => {
                    $scope.documents = response;
                });
            $scope.getDocumentByFolderId = this.getDocumentByFolderId;
        }
        

        getDocument(): ng.IPromise<ng.IHttpResponse<Document[]>>{
            return this.$http.get<Document[]>('/api/documents/DocumentByFolderId/3');
        }

        getDocumentByFolderId(id) {
            console.log("Click on document");
            console.log("Id:" + id);
            console.log("/api/documents/DocumentByFolderId/" + id);
        }
    }
}