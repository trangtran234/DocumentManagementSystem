module rootApp {
    'user strict';

    import DocumentType = rootApp.model.DocumentType;

    export class DocumentController {
        static $inject = ['$http', '$scope'];

        constructor(private $http: ng.IHttpService, private $scope: IUploadDocumentScope) {
            //$scope.documentTypes = [
            //    { id: 1, type: 'IT' },
            //    { id: 2, type: 'HR' }]
            $scope.getDocumentTypes = this.getDocumentTypes;

        }

        getDocumentTypes = () => {
            this.$http.get<DocumentType[]>('/api/documenttypes/DocumentTypes')
                .then((response: ng.IHttpPromiseCallbackArg<DocumentType[]>) => {
                    this.$scope.documentTypes = response.data;
                    console.log(this.$scope.documentTypes);
                });
        }

    }
}

