﻿module rootApp {
    'user strict';
    export class DocumentController {
        static $inject = ['$http', '$scope'];

        constructor(private $http: ng.IHttpService, private $scope: IUploadDocumentScope) {
        }
    }
}

