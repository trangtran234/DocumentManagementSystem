module rootApp {
    
    export class AddDocumentDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/add-document.html';

        public static Factory(): ng.IDirectiveFactory {
            return () => new AddDocumentDirective();
        }
    }    
}