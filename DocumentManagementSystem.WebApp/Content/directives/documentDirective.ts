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
               
                for (var i = 0; i < fs.length; i++) {

                    var document: Document = {};
                    var reader = new FileReader();

                    document.id = Math.floor((Math.random() * 100) + 1);
                    document.documentName = fs[i].name;
                    document.documentSize = fs[i].size;
                    document.statusUpload = -1;
                    
                    reader.onload =  function(onLoadEvent: Event) {

                        let contentFile = (<FileReader>onLoadEvent.target).result;
                        var fileByteArray = new Int8Array(contentFile as ArrayBuffer);
                        document.documentContent = fileByteArray;
                        console.log("Test: " + document.documentContent);
                    };

                    reader.readAsArrayBuffer((<HTMLInputElement>changeEvent.target).files[i]);

                    console.log('State ready ' + reader.readyState);
                    while (reader.readyState === 2) {
                        scope.filesList.push(document);
                        console.log('ID: ' + document.id + ' Name: ' + fs[i].name + " size: " + fs[i].size);
                        console.log('document.documentContent: ' + document.documentContent);
                    }

                    //scope.filesList.push(document);
                    //console.log('ID: ' + document.id + ' Name: ' + fs[i].name + " size: " + fs[i].size);
                    //console.log('document.documentContent: ' + document.documentContent);
                }

                scope.$apply();                                
            });

            scope.deleteDocumentInDialog = function (id) {
                console.log("Document Id " + id);
                for (var i = 0; i < scope.filesList.length; i++) {
                    if (scope.filesList[i].id === id) {
                        scope.filesList.splice(i, 1);
                    }
                }
                return true;
            }

            scope.uploadFile = function () {
                for (var i = 0; i < scope.filesList.length; i++) {
                    if (scope.filesList[i].documentSize > 20480) {
                        alert("Maximum size 20MB: " + scope.filesList[i].documentName);
                    }
                }
                return true;
            };
        }
    }  
}