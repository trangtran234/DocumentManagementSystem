module rootApp {
    'use strict';

    export class DocumentDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/add-document.html';
        static $inject = ['fileModel','$parse'];

        constructor(private $parse) {}

        public static Factory(): ng.IDirectiveFactory {
            return () => new DocumentDirective(this.$inject);
        }

        public link: ng.IDirectiveLinkFn = (
            scope: ng.IScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes
        ) => {
            var model = attributes.fileModel;
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    //modelSetter(scope, element[0].files[0]);
                })
            })
        };
    }  
    
}