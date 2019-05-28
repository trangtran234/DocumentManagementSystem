module rootApp {
    'use strict';
    import Document = rootApp.model.Document;
    interface IEditScope extends ng.IScope {
        document: Document;
    }

    export class EditDocumentDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/editDocument.html';

        public static Factory(): ng.IDirectiveFactory {
            return () => new EditDocumentDirective();
        }

        public link: ng.IDirectiveLinkFn = (
            scope: IEditScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes,
        ) => {
            scope.$on('rootScope:edit', function (event, data) {
                scope.document = data;
            });
        }
    }
}