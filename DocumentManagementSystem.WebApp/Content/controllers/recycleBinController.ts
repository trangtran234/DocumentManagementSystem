module rootApp {
    'user strict';
    export class RecycleBinController {
        static $inject = ['$http', '$scope'];

        constructor(private $http: ng.IHttpService, private $scope: IUploadDocumentScope) {
        }
    }
}