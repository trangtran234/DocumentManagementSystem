module rootApp {
    export class DocumentDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/add-document.html';
        public controller: any = "DocumentController";
        public controllerAs: string = "DocumentController";

        public static Factory(): ng.IDirectiveFactory {
            return () => new DocumentDirective();
        }

        public link: ng.IDirectiveLinkFn = (
            scope: ng.IScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes
        ) => {

        };
    }

    export class DocumentController {
        static $inject = ["$scope", "$element", "$attributes"];
        constructor(protected scope: ng.IScope,
            protected element: ng.IAugmentedJQuery,
            protected attributes: ng.IAttributes) { }

        public uploadDocument() {
            var filePathInput: any = $("#addFile");
        }

    }
    angular.module('rootApp', [])
        .directive('addDocument', DocumentDirective.Factory());
}