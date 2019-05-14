module rootApp {
    'user strict';

    interface IUploadDocumentScope extends ng.IScope {
        files: string[];
    }

    export class DocumentController {
        static $inject = ['$scope'];

        constructor(private $scope: IUploadDocumentScope) {
            $scope.files = ['File 1', 'File 2'];
            
        }               
    }

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
            element.bind("change", function (changeEvent) {

                //console.log('files:', scope.addFile);
                //// Turn the FileList object into an Array
                //scope.files = [];
                //for (var i = 0; i < this.files.length; i++) {
                //    scope.files.push(this.files[i])
                //}
                //scope.$apply();
            });
        }
    }   

}