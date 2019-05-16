module rootApp {
    'user strict';
    import Document = rootApp.model.Document;

    export interface IUploadDocumentScope extends ng.IScope {
        filesList: Array<Document>;
        uploadFile(): boolean;
        deleteDocumentInDialog(id): boolean;
    }

    export class DocumentController {

        constructor(private $scope: IUploadDocumentScope) {
            //$scope.uploadFile = this.uploadFile;
        }      

        //uploadFile(): boolean {
        //    console.log("uploadFile123");
        //    for (var i = 0; i < this.$scope.filesList.length; i++) {
        //        if (this.$scope.filesList[i].documentSize > 20480) {
        //            alert("Maximum size 20MB.");
        //        }
        //    }
        //    return false;
        //}
    }
}

