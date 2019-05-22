module rootApp {
    'use strict';

    interface IMyDocumentScope extends ng.IScope {
        document: Document;
    }

    export class InformationDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/informationDocument.html';
        //public scope = {
        //    documentInfo: '=info'
        //};
        constructor() { }

        public static Factory(): ng.IDirectiveFactory {
            return () => new InformationDirective();
        }

        public link: ng.IDirectiveLinkFn = (
            scope: IMyDocumentScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes
        ) => {
            scope.$on('rootScope:documentInfo', function (event, data) {
                scope.document = data;
            });
        };
    }
}