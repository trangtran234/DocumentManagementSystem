module rootApp {
    'user strict';
    export class DocumentController {
        static $inject = ['$http', '$scope'];
        
        constructor(private $http: ng.IHttpService, private $scope: IUploadDocumentScope) {
            $scope.onSave = this.onSave;
            $scope.uploadFiles = this.uploadFiles;
        }   
        
        onSave = () => {
            
            //reload the list
        }

        uploadFiles = () => {

            console.log("uploadFiles: " + this.$scope.files);
            //transformRequest: function () {
            //    var formData = new FormData();
            //    for (var i = 0; i < this.$scope.files.length; i++) {
            //        formData.append("file" + i, this.$scope.files[i]);
            //    }
            //},

            var formData = new FormData();
            var x = this.$scope.files.length;
            for (var i = 0; i < this.$scope.files.length; i++) {
                formData.append('file', this.$scope.files);
            }

            this.$http({
                url: '/api/upload/uploadDocuments',
                method: 'POST',                
                data: formData,
                transformRequest: angular.identity
            }).then(function (response) {
                console.log('Success: ' + response);
                this.$scope.onSave();
            },
                function (response) {
                    console.log('Fail: ' + response);
                });

        }
    }
}

