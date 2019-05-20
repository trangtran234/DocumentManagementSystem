module rootApp {
    'use strict';
    export class DocumentsListingDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/documentsListing.html';
        public scope = {
            documents: '=',
            getInfoOfDocument: '&actionFile',
            getChildDocumentOfFolder: '&actionFolder'
        }
        constructor() { }

        public static Factory(): ng.IDirectiveFactory {
            return () => new DocumentsListingDirective();
        }

        public link($scope) {
            $scope.clickOnFile = function (id) {
                $scope.getInfoOfDocument()(id);
            }
            $scope.clickOnFolder = function (id) {
                $scope.getChildDocumentOfFolder()(id);
            }
        }
    }
}