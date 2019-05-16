module rootApp {
    'use strict';
    export class TableListViewDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/tableListView.html';
        constructor() { }

        public static Factory(): ng.IDirectiveFactory {
            return () => new TableListViewDirective();
        }
    }
}