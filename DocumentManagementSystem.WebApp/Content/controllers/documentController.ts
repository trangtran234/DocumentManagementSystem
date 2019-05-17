module rootApp {
    'user strict';
    import Document = rootApp.model.Document;

    export interface IUploadDocumentScope extends ng.IScope {
        filesList: Array<Document>;
        uploadFile: (documentList) => void;
        deleteDocumentInDialog: (id) => boolean;
    }

    export class DocumentController {
        static $inject = ['$http', '$scope'];
        
        constructor(private $http: ng.IHttpService, private $scope: IUploadDocumentScope) {
            $scope.uploadFile = this.uploadFile;
        }   
        
        uploadFile = (documentList) => {
            var myJSON = JSON.stringify(documentList);

            console.log("JSON: " + myJSON);

            this.$http.post('/api/upload/uploadDocuments', myJSON)
                .then(
                    function (response) {
                        console.log("Success: " + response);
                    },
                    function (response) {
                        console.log("Fail: " + response);
                    }
                );

        }
    }
}

