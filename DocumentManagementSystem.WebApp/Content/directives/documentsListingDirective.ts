module rootApp {
    'use strict';
    export class DocumentsListingDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/documentsListing.html';
        constructor() { }

        public static Factory(): ng.IDirectiveFactory {
            return () => new DocumentsListingDirective();
        }
    }
}