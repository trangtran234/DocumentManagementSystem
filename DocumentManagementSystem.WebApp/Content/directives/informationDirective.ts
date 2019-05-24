module rootApp {
    'use strict';

    import Document = rootApp.model.Document;

    interface IMyDocumentScope extends ng.IScope {
        document: Document;
        isVisible: boolean;
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
            scope.isVisible = false;
            scope.$on('rootScope:documentInfo', function (event, data) {
                scope.document = data;
            });
            scope.$on('rootScope:isVisible', function (event, data) {
                scope.isVisible = data;
            });
        };
    }
}