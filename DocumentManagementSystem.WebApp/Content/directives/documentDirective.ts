
module rootApp {
    'use strict';

    import Document = rootApp.model.Document;
    import IUploadDocumentScope = rootApp.IUploadDocumentScope;

    export class DocumentDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/add-document.html';

        constructor() { }

        public static Factory(): ng.IDirectiveFactory {
            return () => new DocumentDirective();
        }

        public link: ng.IDirectiveLinkFn = (
            scope: IUploadDocumentScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes
        ) => {
            scope.filesList = [];
            element.bind("change", function (changeEvent: Event) {
                let fs = (<HTMLInputElement>changeEvent.target).files;

                var document: Document = {};
                for (var i = 0; i < fs.length; i++) {
                    document.documentName = fs[i].name;
                    document.documentSize = fs[i].size;
                    document.statusUpload = -1;
                    document.documentType = fs[i].type;
                    
                    scope.filesList.push(document);
                    console.log('Name: ' + fs[i].name + " size: " + fs[i].size);
                }
                scope.$apply();
                
             
            });
        }
    }  
}