module rootApp {
    'user strict';
    import Document = rootApp.model.Document;

    export interface IUploadDocumentScope extends ng.IScope {
        filesList: Array<Document>;
    }

    export class DocumentController {

        constructor(private $scope: IUploadDocumentScope) {
        }           
    }
}

