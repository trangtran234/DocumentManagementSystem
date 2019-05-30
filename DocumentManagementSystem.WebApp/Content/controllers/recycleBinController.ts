module rootApp {
    'user strict';

    import DocumentType = rootApp.model.DocumentType;

    export class RecycleBinController {
        static $inject = ['$http', '$scope'];

        constructor(private $http: ng.IHttpService, private $scope: IUploadDocumentScope) {
            this.$http.get<DocumentType[]>('/api/documenttypes/DocumentTypes')
                .then((response: ng.IHttpPromiseCallbackArg<DocumentType[]>) => {
                    this.$scope.documentTypes = response.data;
                });
        }

    }
}