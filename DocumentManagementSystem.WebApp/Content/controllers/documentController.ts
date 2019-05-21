module rootApp {
    'user strict';
    export class DocumentController {
        static $inject = ['$http', '$scope'];

        constructor(private $http: ng.IHttpService, private $scope: IUploadDocumentScope) {
            $scope.onSave = this.onSave;
            //$scope.uploadFiles = this.uploadFiles;
        }

        onSave = () => {

            //reload the list
        }
    }
}

