module rootApp {
    'user strict';

    import Document = rootApp.model.Document;

    interface IMyDocumentRootScope extends ng.IRootScopeService {
        document: Document; 
    }

    interface IMyDocumentScope extends ng.IScope {
        documents: Document[];
        getChildDocumentOfFolder: (id) => void;
        getInfoOfDocument: (id) => void;
    }

    export class DocumentsListingController  {
        static $inject = ['$http', '$scope', '$rootScope'];

        constructor(private $http: ng.IHttpService, private $scope: IMyDocumentScope, private $rootScope: IMyDocumentRootScope) {
            this.getDocumentIntoListView();
            $scope.getChildDocumentOfFolder = this.getChildDocumentOfFolder;
            $scope.getInfoOfDocument = this.getInfoOfDocument;
        }

        getDocumentIntoListView = () => {
            this.$http.get<Document[]>('/api/documents/DocumentByFolderId/3')
                .then((response: ng.IHttpPromiseCallbackArg<Document[]>) => {
                    this.$scope.documents = response.data;
                });
        }

        getChildDocumentOfFolder = (id) => {
            this.$http.get<Document[]>('/api/documents/DocumentByFolderId/' + id)
                .then((response: ng.IHttpPromiseCallbackArg<Document[]>) => {
                    this.$scope.documents = response.data;
                });

            this.$http.get<Document>('/api/documents/DocumentById/' + id)
                .then((response: ng.IHttpPromiseCallbackArg<Document>) => {
                    var document = response.data;
                    this.$rootScope.$broadcast('rootScope:documentInfo', document)
                });
        }

        getInfoOfDocument = (id) => {
            this.$http.get<Document>('/api/documents/DocumentById/' + id)
                .then((response: ng.IHttpPromiseCallbackArg<Document>) => {
                    this.$rootScope.$broadcast('rootScope:documentInfo', response.data)
                });
        }
    }
}