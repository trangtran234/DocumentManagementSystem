module rootApp {
    'use strict';

    import Document = rootApp.model.Document;
    import DocumentHistory = rootApp.model.DocumentHistory;

    interface IMyDocumentScope extends ng.IScope {
        document: Document;
        isVisible: boolean;
        documentHistories: DocumentHistory[];
        documentHistory: DocumentHistory;
        toStringDocument: () => string;
    }

    export class InformationDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/informationDocument.html';
        //public scope = {
        //    documentInfo: '=info'
        //};
        constructor(private $http: ng.IHttpService) { }

        public static Factory(): ng.IDirectiveFactory {
            const directive = ($http: ng.IHttpService) => new InformationDirective($http);
            directive.$inject = ['$http'];
            return directive;
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

            var http = this.$http;
            http.get<DocumentHistory[]>('/api/documents/DocumentHistories')
                .then((response: ng.IHttpPromiseCallbackArg<DocumentHistory[]>) => {
                    scope.documentHistories = response.data;
                });

            scope.$on('history:sucessed', function (event, data) {
                var actionEvent = data;
                if (actionEvent !== null) {
                    http.get<DocumentHistory[]>('/api/documents/DocumentHistories')
                        .then((response: ng.IHttpPromiseCallbackArg<DocumentHistory[]>) => {
                            scope.documentHistories = response.data;
                        });
                }
            });
        };
    }
}