module rootApp {
    'use strict';
    export class DocumentDirective implements ng.IDirective {
        public restrict: string = "E";
        public require: "ngModel";
        public templateUrl: string = '/Content/directives/add-document.html';
        
        constructor() {}

        public static Factory(): ng.IDirectiveFactory {
            return () => new DocumentDirective();
        }

        public link: ng.IDirectiveLinkFn = (
            scope: ng.IScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes,
            ngModel: ng.INgModelController
        ) => {
            element.bind('change', function (event) {
                
            });
            
        };
    }  
    
}