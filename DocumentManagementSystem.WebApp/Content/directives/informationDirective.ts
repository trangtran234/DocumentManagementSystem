module rootApp {
    'use strict';
    export class InformationDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/informationDocumentTag.html';
        public scope = {
            documentInfo: '=info'
        };
        constructor() { }

        public static Factory(): ng.IDirectiveFactory {
            return () => new InformationDirective();
        }
    }
}