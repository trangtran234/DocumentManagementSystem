module rootApp {
    'user strict';

    import Document = rootApp.model.Document;

    export interface IDocumentService {
        uploadFile(document: Document): ng.IPromise<Document>;
    };

    export class DocumentService implements IDocumentService {

        static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) {

        }

        uploadFile(document: Document): angular.IPromise<Document> {
            return this.$http.post('api/upload', document)
                .then((response: ng.IHttpPromiseCallbackArg<Document>): any => {
                    return <Document>response.data;
                });
        }

        
    }

    factory.$inject = ['$http'];
    function factory($http: ng.IHttpService): IDocumentService {
        return new DocumentService($http);
    }
}