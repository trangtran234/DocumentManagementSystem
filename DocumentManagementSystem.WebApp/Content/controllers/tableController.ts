module rootApp {
    'user strict';

    import Document = rootApp.model.Document;

    interface IDocumentScope extends ng.IScope {
        documents: Document[];
        documentsByFolderId: Document[];
    }

    export class TableController  {

        static $inject = ['$http', '$scope'];

        constructor(private $http: ng.IHttpService, private $scope: IDocumentScope) {
            this.getDocumentByFolderId()
                .then((response: ng.IHttpPromiseCallbackArg<Document[]>): Document[] => {
                    return <Document[]>response.data;
                })
                .then((response: Document[]) => {
                    $scope.documents = response;
            });
        }

        getDocumentByFolderId(): ng.IPromise<ng.IHttpResponse<Document[]>>{
            return this.$http.get<Document[]>('/api/documents/DocumentByFolderId/3');
        }

        


    }

    //export class TableController {
    //    public Documents: Document[];

    //    static $inject = ['$scope', '$http']

    //    constructor(private $http: ng.IHttpService) {
    //        this.getDocuments();
    //    }

    //    getDocuments(): Document[] {
    //        return this.$http.get('/api/documents/documentDTO')
    //            .then((response: ng.IHttpPromiseCallbackArg<Document[]>): Document[] => {
    //                return <Document[]>response.data;
    //            });
    //    }
    //}

    //export class TableController
    //{
    //    public scope;
    //    static $inject = ['$scope'];
    //    public documentDTO = ['Catherine Grant', 'Monica Grant',
    //        'Christopher Grant', 'Jennifer Grant'
    //    ];

    //    constructor(private $scope: ng.IScope) {
    //        this.scope = $scope;
    //        this.scope.Documents = this.documentDTO;
    //    }
    //}
}