module rootApp {
    'use strict';

    import Document = rootApp.model.Document;
    import DocumentHistory = rootApp.model.DocumentHistory;

    interface IMyDocumentScope extends ng.IScope {
        document: Document;
        isVisible: boolean;
        documentHistories;
        messages;
    }

    export class InformationDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/informationDocument.html';

        constructor(private $http: ng.IHttpService, private $sce: ng.ISCEService) { }

        public static Factory(): ng.IDirectiveFactory {
            const directive = ($http: ng.IHttpService, $sce: ng.ISCEService) => new InformationDirective($http, $sce);
            directive.$inject = ['$http', '$sce'];
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
            var sce = this.$sce;
            scope.documentHistories = new Array<DocumentHistory>();
            scope.messages = new Array<string>();

            http.get<DocumentHistory[]>('/api/documents/DocumentHistories')
                .then((response: ng.IHttpPromiseCallbackArg<DocumentHistory[]>) => {
                    angular.forEach(response.data, function (value, key) {
                        var docHistory = new DocumentHistory(value.id, value.documentId, value.actionEvent, value.account, value.date);

                        var msg: string;
                        switch (docHistory.actionEvent) {
                            case 1:
                                msg = sce.trustAsHtml('Created by <a href="">' + docHistory.account.username + '</a> at ' + docHistory.date);
                                break;
                            case 2:
                                msg = sce.trustAsHtml('Updated by <a href="">' + docHistory.account.username + '</a> at ' + docHistory.date);
                                break;
                            case 3:
                                msg = sce.trustAsHtml('Deleted by <a href="">' + docHistory.account.username + '</a> at ' + docHistory.date);
                                break;
                        }
                        scope.messages.push(msg);

                        scope.documentHistories.push(docHistory);
                    })
                });

            scope.$on('history:sucessed', function (event, data) {
                var actionEvent = data;
                if (actionEvent !== null) {
                    http.get<DocumentHistory[]>('/api/documents/DocumentHistories')
                        .then((response: ng.IHttpPromiseCallbackArg<DocumentHistory[]>) => {
                            scope.documentHistories = [];

                            scope.messages = [];

                            angular.forEach(response.data, function (value, key) {
                                var docHistory = new DocumentHistory(value.id, value.documentId, value.actionEvent, value.account, value.date);

                                var msg: string;
                                switch (docHistory.actionEvent) {
                                    case 1:
                                        msg = sce.trustAsHtml('Created by <a href="">' + docHistory.account.username + '</a> at ' + docHistory.date);
                                        break;
                                    case 2:
                                        msg = sce.trustAsHtml('Updated by <a href="">' + docHistory.account.username + '</a> at ' + docHistory.date);
                                        break;
                                    case 3:
                                        msg = sce.trustAsHtml('Deleted by <a href="">' + docHistory.account.username + '</a> at ' + docHistory.date);
                                        break;
                                }
                                scope.messages.push(msg);

                                scope.documentHistories.push(docHistory);
                            })
                        });
                }
            });
        };
    }
}