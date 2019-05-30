module rootApp {
    'user strict';

    import DocumentType = rootApp.model.DocumentType;

    export class DocumentController {
        static $inject = ['$http', '$scope'];

        constructor(private $http: ng.IHttpService, private $scope: IUploadDocumentScope) {

        }

    }
}

